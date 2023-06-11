using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Classes;
using Services.Models;
using Services.Viewmodel;
using System.Diagnostics;
using WebApplication2.Controllers;
using WebFinal.Models;

namespace WebFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

      
        public IActionResult Main() {
            
            ProductServices productServices = new ProductServices();

            var vm = productServices.GetProductForAdmin();

            return View();
        }

        public IActionResult Sale()

        {
            ProductServices productServices = new ProductServices();

            var vm = productServices.GetProductForAdmin();

            return View(vm);

        }
    }
}