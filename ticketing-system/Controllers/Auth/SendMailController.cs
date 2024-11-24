using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ticketing_system.Classes;
using ticketing_system.Models.Email;
using ticketing_system.Models.User;
using ticketing_system.Models.User.Services.Abstraction;

namespace ticketing_system.Controllers.Auth
{
    public class SendMailController : Controller
    {
        public IConfiguration Configuration { get; }
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        public SendMailController(IConfiguration configuration, IUserService userService, IEmailService emailService)
        {
            Configuration = configuration;
            _userService = userService;
            _emailService = emailService;
        }

        public static int generatedCode = 0;

        // Do ovde se dolazi iz metode CheckMailAsync.
        public async Task<IActionResult> Index()
        {
            // Dobijamo email iz sesije.
            string email = HttpContext.Session.GetString("email");

            // Generišemo kod.
            CodeGenerator codeGenerator = new CodeGenerator();
            codeGenerator.generate();

            generatedCode = codeGenerator.Code;
            HttpContext.Session.SetString("generated_code", generatedCode.ToString());

            // Šaljemo kod na email korisnika.
            await _emailService.sendMailAsync(email, generatedCode);

            return View();
        }

        // Do ove metode se dolazi kada korisnik unese email u email u polje, da bi mu stigao gen code. 
        [HttpPost]
        public async Task<IActionResult> CheckMailAsync(string email)
        {
            // Provera da li je unet validan string.
            if (string.IsNullOrWhiteSpace(email) || email.IsNullOrEmpty())
            {
                ModelState.AddModelError("EmailNull", "You need to enter valid email adress.");
                return View("~/Views/ChangePass/Index.cshtml");
            }

            // Pokušavamo da dobijemo korisnika po email-u.
            User user = await _userService.GetUserByEmailAsync(email);

            // Ako ne postoji korisnik sa tom email adresom.
            if (user == null)
            {
                ModelState.AddModelError("WrongEmail", "Wrong email adress.");
                return View("~/Views/ChangePass/Index.cshtml");
            }

            HttpContext.Session.SetString("email", email);
            HttpContext.Session.SetString("pass", user.Password);

            return RedirectToAction("Index", "SendMail", email);
        }

        // ovde da se preusmeri kada se unese kod i klikne na dugme.
        // da se prvo proveri kod, pa onda i sesija (da li je korisnik već bio prijavljen)
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
