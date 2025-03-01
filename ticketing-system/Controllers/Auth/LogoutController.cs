using Microsoft.AspNetCore.Mvc;

namespace ticketing_system.Controllers.Auth
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete("RememberMe");
            Response.Cookies.Delete("UserId");

            return RedirectToAction("Index", "Login");
        }
    }
}
