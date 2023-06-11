using Microsoft.AspNetCore.Mvc;
using Services.Classes;

namespace WebFinal.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            UserServices users = new UserServices();
   
            if (users.CheckUsers(username, password))
            {
                HttpContext.Session.SetString("UserSession", username);
                return RedirectToAction("Main", "Home");
            }
            else
            {

                ViewBag.Mesaj = users.ErrorMesage;
                return View();

            }

        }

    }
}
