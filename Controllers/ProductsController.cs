using System;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreSEOTemplate.Controllers
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
