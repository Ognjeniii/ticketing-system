using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ticketing_system.Classes;
using ticketing_system.Models.User;
using ticketing_system.Models.User.Services.Abstraction;

namespace ticketing_system.Controllers.Auth
{
    public class SendMailController : Controller
    {
        public IConfiguration Configuration { get; }
        private readonly IUserService _userService;
        public SendMailController(IConfiguration configuration, IUserService userService)
        {
            Configuration = configuration;
            _userService = userService;
        }

        public static int generatedCode = 0;

        public IActionResult Index()
        {
            // vrv se ovde šalje mail
            CodeGenerator codeGenerator = new CodeGenerator();
            codeGenerator.generate();

            generatedCode = codeGenerator.Code;

            Console.WriteLine(generatedCode);

            var sifra = Configuration["Values:Pass1"];
            Console.WriteLine("Pass: " + sifra);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckMailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email.IsNullOrEmpty())
            {
                ModelState.AddModelError("EmailNull", "You need to enter valid email adress.");
                return View("~/Views/ChangePass/Index.cshtml");
            }

            User user = await _userService.GetUserByEmailAsync(email);

            if (user == null)
            {
                ModelState.AddModelError("WrongEmail", "Wrong email adress.");
                return View("~/Views/ChangePass/Index.cshtml");
            }

            return RedirectToAction("Index", "SendMail");
        }

        [HttpPost]
        public IActionResult CheckCode(string Code)
        {
            int codeInt = Int32.Parse(Code);
            if (codeInt == generatedCode)
            {
                return RedirectToAction("Index", "Login");
            }

            return RedirectToAction("Index", "ChangePass");
        }
    }
}
