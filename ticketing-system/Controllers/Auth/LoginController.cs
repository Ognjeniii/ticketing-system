using Microsoft.AspNetCore.Mvc;

namespace ticketing_system.Controllers.Auth
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
