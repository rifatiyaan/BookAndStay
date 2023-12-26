using BookAndStay.Application.common.Interface;
using BookAndStay.Web.Models;
using BookAndStay.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookAndStay.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll(includedProperties: ""),
                Nights = 2,
                CheckIn = DateOnly.FromDateTime(DateTime.Now)
            };
            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
