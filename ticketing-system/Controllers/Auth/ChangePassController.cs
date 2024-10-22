using Microsoft.AspNetCore.Mvc;
using ticketing_system.Models.ViewModels;

namespace ticketing_system.Controllers.Auth
{
    public class ChangePassController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePassword(ChangePassViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/ChangePass/Index.cshtml", data);
            }

            Console.WriteLine(data.Username + " . " + data.OldPassword + " . " + data.NewPassword + " . " + data.RepeatedNewPassword);
            Console.WriteLine("Došli smo do UpdatePassword metode u ChangePassController-u.");
            return Ok();
        }
    }
}
