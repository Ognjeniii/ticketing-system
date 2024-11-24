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

        public async Task<IActionResult> CheckCode(string code)
        {
            string generatedCode = TempData["generated_code"].ToString();

            if (!code.Equals(generatedCode))
            {
                ModelState.AddModelError("BadCode", "You entered the wrong code.");
                return View("~/Views/SendMail/Index.cshtml");
            }

            string pass = (string)TempData["pass"];
            Console.WriteLine("Password: " + pass);

            return View();
        }
    }
}
