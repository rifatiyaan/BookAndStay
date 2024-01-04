using BookAndStay.Application.common.Interface;
using BookAndStay.Application.NewFolder;
using BookAndStay.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookAndStay.Web.Controllers
{
	[Authorize(Roles = SD.AdminRole)]
	public class CategoryController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment webHostEnvironment;
		public CategoryController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
			_unitOfWork = unitOfWork;
			this.webHostEnvironment = webHostEnvironment;
		}
		public IActionResult Index()
		{

			var categoryList = _unitOfWork.Category.GetAll();
			return View(categoryList);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Category Category)
		{
			if (ModelState.IsValid)
			{
				if (Category.Image != null)
				{
					string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Category.Image.FileName);
					string imagePath = Path.Combine(webHostEnvironment.WebRootPath, @"images\Category");
					using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
					{
						Category.Image.CopyTo(fileStream);
						Category.ImageUrl = @"\images\Category\" + fileName;
					}
				}
				else
				{
					Category.ImageUrl = "https://archive.org/download/placeholder-image/placeholder-image.jpg";
				}
				_unitOfWork.Category.Add(Category);
				_unitOfWork.Category.Save();
				TempData["success"] = "Category is successfully created";
				return RedirectToAction("Index");
			}
			return View();

		}

		public IActionResult Update(int? id)
		{
			if (id != 0 && id != null)
			{
				Category category = _unitOfWork.Category.Get(x => x.Id == id);
				return View(category);
			}

			return NotFound();


		}
		[HttpPost]
		public IActionResult Update(Category Category)
		{
			if (ModelState.IsValid)
			{
				if (Category.Image != null)
				{
					string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Category.Image.FileName);
					string imagePath = Path.Combine(webHostEnvironment.WebRootPath, @"images\Category");

					if (!string.IsNullOrEmpty(Category.ImageUrl))
					{
						var oldImagePath = Path.Combine(webHostEnvironment.WebRootPath, Category.ImageUrl.TrimStart('\\'));
						if (System.IO.File.Exists(imagePath))
						{
							System.IO.File.Delete(imagePath);
						}
					}

					using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
					{
						Category.Image.CopyTo(fileStream);
						Category.ImageUrl = @"\images\Category\" + fileName;
					}
				}


				_unitOfWork.Category.Update(Category);
				_unitOfWork.Category.Save();
				TempData["success"] = "Category is successfully updated";
				return RedirectToAction("Index");
			}
			return View();
		}

		public IActionResult Delete(int? id)
		{
			if (id == 0 && id == null)
			{
				return NotFound();
			}
			Category CategorysToDelete = _unitOfWork.Category.Get(y => y.Id == id);
			if (CategorysToDelete == null)
			{
				return NotFound();
			}
			return View(CategorysToDelete);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Category CategoryToDelete = _unitOfWork.Category.Get(z => z.Id == id);
			if (CategoryToDelete != null)
			{
				_unitOfWork.Category.Delete(CategoryToDelete);
				_unitOfWork.Category.Save();
				TempData["success"] = "Category is successfully deleted";
				return RedirectToAction("Index");
			}
			return NotFound();
		}
	}
}
