using Microsoft.AspNetCore.Mvc;
using ticketing_system.Models.User;
using ticketing_system.Models.User.Services.Abstraction;

namespace ticketing_system.Controllers
{
    public class BaseController : Controller
    {
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
