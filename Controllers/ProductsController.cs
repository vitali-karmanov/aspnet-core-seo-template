using System;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_Core_MVC_SEO_Friendly_Template.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductExample()
        {
            return View();
        }
    }
}
