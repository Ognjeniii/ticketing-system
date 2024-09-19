using Microsoft.AspNetCore.Mvc;

namespace ticketing_system.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            var cookie = Request.Cookies["RememberMe"];
            var session = HttpContext.Session.GetString("token");

            if (cookie != null || session != null)
            {
                return RedirectToAction("Home");
            }

            return RedirectToAction("Index", "Login");    
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
