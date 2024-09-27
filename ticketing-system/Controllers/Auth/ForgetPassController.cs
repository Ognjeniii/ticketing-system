using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.CodeDom.Compiler;
using ticketing_system.Classes;

namespace ticketing_system.Controllers.Auth
{
    public class ForgetPassController : Controller
    {
        public IConfiguration Configuration { get; }
        public ForgetPassController(IConfiguration configuration)
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
        public IActionResult CheckMail(string Email)
        {   
            if (!Email.IsNullOrEmpty())
            {
                if (Email.Equals("email"))
                {
                    return RedirectToAction("Index");
                }
            }

            Console.WriteLine("Mail ne postoji u bazi.");
            return RedirectToAction("Index", "ChangePass");
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
