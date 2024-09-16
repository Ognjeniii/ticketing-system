using Microsoft.AspNetCore.Mvc;

namespace ticketing_system.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            // ovde bi trebalo da proverimo da li je korisnik prethodno prijavljen na sistem
            if (Request.Cookies.ContainsKey("RememberMe") || HttpContext.Session.Keys.Contains("UserId"))
            {
                 return RedirectToAction("Home"); // treba da se napravi neka početna stranica
            }
            else
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
