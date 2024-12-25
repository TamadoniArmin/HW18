using HW18.Models.Repositories;
using HW18.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace HW18.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            if(InMemmoryDB.IsLogin)
            {
                CategoriesRepository categoriesRepository = new CategoriesRepository();
                var Categoris = categoriesRepository.Categories();
                return View(Categoris);
            }
            TempData["ErrorMessage"] = "You haven't login yet!! (In order to see this page you should first login)";
            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public IActionResult CategoryPage()
        {
            if (InMemmoryDB.IsLogin)
            {
                return RedirectToAction("Index", "Category");
            }
            TempData["ErrorMessage"] = "You haven't login yet!! (In order to see this page you should first login)";
            return RedirectToAction("Login", "User");
        }
    }
}
