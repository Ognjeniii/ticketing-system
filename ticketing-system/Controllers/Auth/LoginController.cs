using Microsoft.AspNetCore.Mvc;
using ticketing_system.Models.ViewModels;

namespace ticketing_system.Controllers.Auth
{
    public class LoginController : Controller
    {
        //private readonly IUserService _userService;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(model.Username.Equals("user") && model.Password.Equals("pass"))
            {
                Console.WriteLine("Uspešna prijava!");

                // setujemo kuki
                Response.Cookies.Append("RememberMe", "true", new CookieOptions
                {
                    Expires = DateTime.UtcNow.AddDays(30)
                });

                // setujemo sesiju
                HttpContext.Session.SetString("token", model.Username);

                return RedirectToAction("Index", "Base");
            }

            Console.WriteLine("Neuspešna prijava!");
            return Index();
        }
    }
}
