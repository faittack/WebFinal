using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace WebApplication2.Controllers
{
    public class Base : Controller
    {
        public bool IsSesionalAlive()
        {
            var value = HttpContext.Session.GetString("UserSession");
            if (value == null)
            {
                return false;
            }else
            return true;
        }



        public override void OnActionExecuting(ActionExecutingContext filtercontext)
        {
            if (IsSesionalAlive()== false) {
                TempData["error"] = "Bu sayfayı görüntülemek için giriş yapmalısınız!!!";
                filtercontext.Result = RedirectToAction("Login", "Login");
                return;
                 
              }
        }
    }
}
