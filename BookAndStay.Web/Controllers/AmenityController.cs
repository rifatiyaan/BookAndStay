using BookAndStay.Application.common.Interface;
using BookAndStay.Application.NewFolder;
using BookAndStay.Domain.Entities;
using BookAndStay.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookAndStay.Web.Controllers
{
	[Authorize(Roles = SD.AdminRole)]
	public class AmenityController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public AmenityController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			var Amenitys = _unitOfWork.Amenity.GetAll(includedProperties: "Category");
			return View(Amenitys);
		}
		public IActionResult Create()
		{
			AmenityVM AmenityNumberVM = new()
			{
				CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
				{
					Text = u.RoomType,
					Value = u.Id.ToString()
				})
			};
			return View(AmenityNumberVM);
		}
		[HttpPost]
		public IActionResult Create(AmenityVM AmenityNumberVM)
		{

			if (ModelState.IsValid)
			{
				_unitOfWork.Amenity.Add(AmenityNumberVM.Amenity);
				_unitOfWork.Amenity.Save();
				TempData["success"] = "Amenity is successfully created";
				return RedirectToAction("Index");
			}

			return View(AmenityNumberVM);

		}

		public IActionResult Update(int AmenityNumberId)
		{
			AmenityVM AmenityNumberVM = new()
			{
				CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
				{
					Text = u.RoomType,
					Value = u.Id.ToString()
				}),
				Amenity = _unitOfWork.Amenity.Get(x => x.Id == AmenityNumberId)

			};
			if (AmenityNumberVM.Amenity == null)
			{
				return NotFound();
			}

			return View(AmenityNumberVM);

		}

		[HttpPost]
		public IActionResult Update(AmenityVM AmenityNumberVM)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Amenity.Update(AmenityNumberVM.Amenity);
				_unitOfWork.Amenity.Save();
				TempData["success"] = "Category is successfully updated";
				return RedirectToAction("Index");
			}
			return View();
		}

		public IActionResult Delete(int? AmenityNumberId)
		{
			AmenityVM AmenityNumberVM = new()
			{
				CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
				{
					Text = u.RoomType,
					Value = u.Id.ToString()
				}),
				Amenity = _unitOfWork.Amenity.Get(x => x.Id == AmenityNumberId)

			};
			if (AmenityNumberVM.Amenity == null)
			{
				return NotFound();
			}
			return View(AmenityNumberVM);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int? AmenityNumberId)
		{
			Amenity amenity = _unitOfWork.Amenity.Get(x => x.Id == AmenityNumberId);
			if (amenity != null)
			{
				_unitOfWork.Amenity.Delete(amenity);
				_unitOfWork.Amenity.Save();
				TempData["success"] = "Amenity is successfully deleted";
				return RedirectToAction("Index");
			}
			return View();
		}

	}
}
