using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Classes;
using Services.Models;
using Services.Viewmodel;

namespace WebFinal.Controllers
{
    public class UserListController : Controller
    {
        private readonly Services.Models.FinalPrjContext _context;

        public IActionResult Index()
        {
            UserServices userServices = new UserServices();

            var model = userServices.GetUsers();

            return View(model);

        }

        public IActionResult Delete(long id)
        {
            UserServices userServices = new UserServices();

            var model = userServices.DeleteUsers(id);


            return RedirectToAction("Index", "Admin");
        }



    }
}
