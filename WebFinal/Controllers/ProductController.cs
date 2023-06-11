using Microsoft.AspNetCore.Mvc;
using Services.Classes;
using Services.Viewmodel;
using WebApplication2.Controllers;

namespace WebFinal.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ProductServices productServices = new ProductServices();

            var vm = productServices.GetProductForAdmin();

            return View(vm);
        }

         public IActionResult Product()
        {

            return View();


        }
        [HttpPost]
        public IActionResult Product(ProductVMI vm)
        {
            ProductServices productServices = new ProductServices();
            
           productServices.AddProduct(vm);

            return RedirectToAction("Index", "Admin");
        }



    }
}
