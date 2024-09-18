using Microsoft.AspNetCore.Mvc;

namespace ticketing_system.Controllers.Auth
{
    public class ForgetPassController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CheckMail()
        {
            return RedirectToAction("Index");
        }
    }
}
