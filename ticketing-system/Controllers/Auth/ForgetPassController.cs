using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using ticketing_system.Models.User;
using ticketing_system.Models.User.Services.Abstraction;

namespace ticketing_system.Controllers.Auth
{
    public class ForgetPassController : Controller
    {
        private readonly IUserService _userService;

        public ForgetPassController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Do ove metode dolazimo kada korisnik unese kod u polje.
        public async Task<IActionResult> CheckCode(string code)
        {
            // Dobijamo kod iz sesije.
            string generatedCode = HttpContext.Session.GetString("generated_code");

            // Ako unet i generisani kod nisu isti, vraća se greška.
            if (!code.Equals(generatedCode))
            {
                ModelState.AddModelError("BadCode", "You entered the wrong code.");
                return View("~/Views/SendMail/Index.cshtml");
            }

            HttpContext.Session.SetString("right_code", "t");

            return View("~/Views/ChangePass/Index.cshtml");
        }
    }
}
