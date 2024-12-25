using HW18.Models.Entities;
using HW18.Models.Interfaces.Products;
using HW18.Models.Repositories;
using HW18.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace HW18.Controllers
{
    public class ProductController : Controller
    {
        ProductService productService = new ProductService();
        public IActionResult Index() 
        {
            if(InMemmoryDB.IsLogin)
            {
                var Produts = productService.GetAllProducts();
                return View(Produts);
            }
            TempData["ErrorMessage"] = "You haven't login yet!! (In order to see this page you should first login)";
            return RedirectToAction("Login", "User");
        }
        public IActionResult AddProduct()
        {
            if (InMemmoryDB.IsLogin) { return View(); }
            TempData["ErrorMessage"] = "You haven't login yet!! (In order to see this page you should first login)";
            return RedirectToAction("Login", "User");
        }
        [HttpPost]
        public IActionResult AddProduct(string name,int price,int qty,int categoryId)
        {
            if (InMemmoryDB.IsLogin)
            {
                var Result = productService.AddProduct(name, price, qty, categoryId);
                if (Result)
                {
                    ViewBag.Message = "Product has been added succesefuly";
                }
                else
                {
                    ViewBag.ErrorMessage = "Ooop....Something goes woring! Please try againe";
                }
                return View();
            }
            TempData["ErrorMessage"] = "You haven't login yet!! (In order to see this page you should first login)";
            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public IActionResult GetProductsByCategory(int id)
        {
            if (InMemmoryDB.IsLogin)
            {
                var Products = productService.GetProductByCategory(id);
                return View(Products);
            }
            TempData["ErrorMessage"] = "You haven't login yet!! (In order to see this page you should first login)";
            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public IActionResult ProductPage()
        {
            if (InMemmoryDB.IsLogin)
            {
                return RedirectToAction("Index", "Product");
            }
            TempData["ErrorMessage"] = "You haven't login yet!! (In order to see this page you should first login)";
            return RedirectToAction("Login", "User");
        }
    }
}
