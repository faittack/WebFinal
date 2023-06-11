using Microsoft.AspNetCore.Mvc;
using Services.Classes;
using Services.Viewmodel;
using System.Numerics;
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

        public IActionResult Edit(long id)
        {
            ProductServices productServices = new ProductServices();

            ProductVM productVM = productServices.SearchProduct(id);

            return View(productVM);
        }
        [HttpPost]
        public IActionResult Edit(ProductVMI vm)
        {
            ProductServices productServices = new ProductServices();

            productServices.EditProduct(vm);

            return RedirectToAction("Index", "Admin");
        }

        public IActionResult Delete(long id)
        {
            ProductServices productServices = new ProductServices();

            var value = productServices.SearchProduct(id);

            productServices.DeleteProduct(value);

            return RedirectToAction("Index", "Admin");
        }


    }
}
