using Microsoft.AspNetCore.Mvc;
using ticketing_system.Models.User;
using ticketing_system.Models.User.Services.Abstraction;

namespace ticketing_system.Controllers
{
    // Ovo je početni kontroler - prvi do kog se dođe prilikom startovanja aplikacije
    public class BaseController : Controller
    {
        // Prva metoda do koje se dolazi prilikom pokretanja aplikacije
        private readonly IUserService _userService;
        public BaseController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            User user = new User
                (
                    3,
                    1,
                    "Pera",
                    "Peric",
                    "perap@company.rs",
                    "perap",
                    "pera123",
                    "software engineer",
                    new DateTime(2024, 10, 6)
                );

            _userService.CreateUserAsync(user);

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
                return RedirectToAction("Home");
            }

            // Korisnik nije prijavljen, šalje se na prijavu
            return RedirectToAction("Index", "Login");
        }
    }
}
