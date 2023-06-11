using Microsoft.AspNetCore.Mvc;
using Services.Classes;
using Services.Viewmodel;
using WebApplication2.Controllers;
using WebFinal.Models;

namespace WebFinal.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            ProductServices productServices = new ProductServices();
        
            var vm = productServices.GetProductForAdmin();
            
            return View(vm);
        }
       

    }
}
