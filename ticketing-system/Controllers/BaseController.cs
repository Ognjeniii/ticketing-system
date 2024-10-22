using Microsoft.AspNetCore.Mvc;
using ticketing_system.Models.User;
using ticketing_system.Models.User.Services.Abstraction;

namespace ticketing_system.Controllers
{
    // Ovo je početni kontroler - prvi do kog se dođe prilikom startovanja aplikacije
    public class BaseController : Controller
    {
        private readonly IUserService _userService;
        // Prva metoda do koje se dolazi prilikom pokretanja aplikacije 
        public BaseController(IUserService userService)
        {
            _userService = userService;
        }

        // Druga metoda po redu koja se pokreće
        public async Task<IActionResult> Index()
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
