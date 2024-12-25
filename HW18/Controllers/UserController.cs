using HW18.Models.Entities;
using HW18.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace HW18.Controllers
{
    public class UserController : Controller
    {
        UsersService usersService = new UsersService();
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username,string password)
        {
            var Result =usersService.Login(username,password);
            if (Result)
            { 
                InMemmoryDB.IsLogin=true;
                return RedirectToAction("Index", "Product"); 
            }
            ViewBag.ErrorMessage = "Password or Username is incorrect!!";
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(string name,string family,string username, string password)
        {
            var result2=usersService.Register(name,family,username,password);
            if (result2) { return RedirectToAction("Login", "User"); }
            ViewBag.ErrorMessage = "This username is already taken!";
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            InMemmoryDB.IsLogin = false;

            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public IActionResult LoginPage()
        {
            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public IActionResult RegisterPage()
        {
            return RedirectToAction("Register", "User");
        }


    }
}
