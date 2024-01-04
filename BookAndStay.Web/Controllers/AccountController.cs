using BookAndStay.Application.common.Interface;
using BookAndStay.Application.NewFolder;
using BookAndStay.Domain.Entities;
using BookAndStay.Web.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookAndStay.Web.Controllers
{
	public class AccountController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public AccountController(IUnitOfWork unitOfWork,
								 UserManager<ApplicationUser> userManager,
								 SignInManager<ApplicationUser> signInManager,
								 RoleManager<IdentityRole> roleManager)
		{
			_unitOfWork = unitOfWork;
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}

		public IActionResult AccessDenied()
		{
			return View();
		}


		public IActionResult Login(string returnUrl = null)
		{
			returnUrl ??= Url.Content("~/");

			LoginVM loginVM = new()
			{
				ReturnUrl = returnUrl,
			};
			return View(loginVM);
		}
		public IActionResult Register(string returnUrl = null)
		{

			returnUrl ??= Url.Content("~/");
			if (!_roleManager.RoleExistsAsync(SD.AdminRole).GetAwaiter().GetResult())
			{
				_roleManager.CreateAsync(new IdentityRole(SD.AdminRole)).Wait();
				_roleManager.CreateAsync(new IdentityRole(SD.CustomerRole)).Wait();
			}

			RegisterVM registerVM = new()
			{
				RoleList = _roleManager.Roles.Select(x => new SelectListItem
				{
					Text = x.Name,
					Value = x.Name
				}),
				ReturnUrl = returnUrl
			};
			return View(registerVM);
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterVM registerVm)
		{

			if (ModelState.IsValid)
			{
				ApplicationUser user = new()
				{
					Name = registerVm.Name,
					Email = registerVm.Email,
					PhoneNumber = registerVm.PhoneNumber,
					NormalizedEmail = registerVm.Email.ToUpper(),
					EmailConfirmed = true,
					UserName = registerVm.Email,
					CreatedDate = DateTime.Now
				};

				var result = await _userManager.CreateAsync(user, registerVm.Password);

				if (result.Succeeded)
				{
					if (!string.IsNullOrEmpty(registerVm.Role))

					{
						await _userManager.AddToRoleAsync(user, registerVm.Role);
					}
					else
					{
						await _userManager.AddToRoleAsync(user, SD.CustomerRole);
					}
					await _signInManager.SignInAsync(user, isPersistent: false);
					if (string.IsNullOrEmpty(registerVm.ReturnUrl))
					{
						return RedirectToAction("Index", "Home");
					}
					else
					{
						return LocalRedirect(registerVm.ReturnUrl);
					}
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			registerVm.RoleList = _roleManager.Roles.Select(x => new SelectListItem
			{
				Text = x.Name,
				Value = x.Name
			});
			return View(registerVm);
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginVM loginVm)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(loginVm.Email, loginVm.Password, loginVm.RememberMe, lockoutOnFailure: false);

				if (result.Succeeded)
				{

					if (string.IsNullOrEmpty(loginVm.ReturnUrl))
					{
						return RedirectToAction("Index", "Home");
					}
					else
					{
						return LocalRedirect(loginVm.ReturnUrl);
					}
				}
				else
				{
					ModelState.AddModelError("", "Invalid Login Attempt");
				}

			}

			return View(loginVm);
		}

		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}
