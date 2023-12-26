using BookAndStay.Application.common.Interface;
using BookAndStay.Domain.Entities;
using BookAndStay.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookAndStay.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoomController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var rooms = _unitOfWork.Room.GetAll(includedProperties: "Category");
            return View(rooms);
        }
        public IActionResult Create()
        {
            RoomNumberVM roomNumberVM = new RoomNumberVM()
            {
                RoomList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.RoomType,
                    Value = u.Id.ToString()
                })
            };
            return View(roomNumberVM);
        }
        [HttpPost]
        public IActionResult Create(RoomNumberVM roomNumberVM)
        {
            bool roomnumberExist = _unitOfWork.Room.Any(x => x.Room_Number == roomNumberVM.Room.Room_Number);
            if (ModelState.IsValid && !roomnumberExist)
            {
                _unitOfWork.Room.Add(roomNumberVM.Room);
                _unitOfWork.Room.Save();
                TempData["success"] = "Room is successfully created";
                return RedirectToAction("Index");
            }
            if (roomnumberExist)
            {
                TempData["error"] = "This roomnumber already exists.";
            }
            return View(roomNumberVM);

        }

        public IActionResult Update(int roomNumberId)
        {
            RoomNumberVM roomNumberVM = new()
            {
                RoomList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.RoomType,
                    Value = u.Id.ToString()
                }),
                Room = _unitOfWork.Room.Get(x => x.Room_Number == roomNumberId)

            };
            if (roomNumberVM.Room == null)
            {
                return NotFound();
            }

            return View(roomNumberVM);

        }

        [HttpPost]
        public IActionResult Update(RoomNumberVM roomNumberVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Room.Update(roomNumberVM.Room);
                _unitOfWork.Room.Save();
                TempData["success"] = "Category is successfully updated";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? roomNumberId)
        {
            RoomNumberVM roomNumberVM = new()
            {
                RoomList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.RoomType,
                    Value = u.Id.ToString()
                }),
                Room = _unitOfWork.Room.Get(x => x.Room_Number == roomNumberId)

            };
            if (roomNumberVM.Room == null)
            {
                return NotFound();
            }
            return View(roomNumberVM);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? roomNumberId)
        {
            Room room = _unitOfWork.Room.Get(x => x.Room_Number == roomNumberId);
            if (room != null)
            {
                _unitOfWork.Room.Delete(room);
                _unitOfWork.Room.Save();
                TempData["success"] = "Category is successfully deleted";
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
