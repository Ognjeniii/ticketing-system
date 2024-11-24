using Microsoft.AspNetCore.Mvc;
using ticketing_system.Classes;
using ticketing_system.Models.User;
using ticketing_system.Models.User.Services.Abstraction;

namespace ticketing_system.Controllers
{
    // Ovo je početni kontroler - prvi do kog se dođe prilikom startovanja aplikacije
    public class BaseController : Controller
    {

        // Druga metoda po redu koja se pokreće
        public IActionResult Index()
        {
            var cookie = Request.Cookies["RememberMe"];
            var session = HttpContext.Session.GetString("token");

            // Korisnik je prijavlen, šalje se na početni ekran
            if (cookie != null || session != null)
            {
                return RedirectToAction("Home");
            }

            // Korisnik nije prijavljen, šalje se na prijavu
            return RedirectToAction("Index", "Login");
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Home()
        {
            var cookie = Request.Cookies["RememberMe"];
            var session = HttpContext.Session.GetString("token");

            // Korisnik je prijavlen, šalje se na početni ekran
            if (cookie != null || session != null)
            {
                return View("~/Views/Base/Home.cshtml");
            }

            // Korisnik nije prijavljen, šalje se na prijavu
            return RedirectToAction("Index", "Login");
        }
    }
}
