using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ticketing_system.Classes;

namespace ticketing_system.Controllers.Auth
{
    public class SendMailController : Controller
    {
        public IConfiguration Configuration { get; }
        public SendMailController(IConfiguration configuration)
        {
            Configuration = configuration;
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
        public IActionResult CheckMail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email.IsNullOrEmpty())
            {
                ModelState.AddModelError("EmailNull", "You need to enter valid email adress.");
                return View("~/Views/ChangePass/Index.cshtml");
            }



            //if (!Email.IsNullOrEmpty())
            //{
            //    if (Email.Equals("email"))
            //    {
            //        return RedirectToAction("Index");
            //    }
            //}

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
