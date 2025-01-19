using Microsoft.AspNetCore.Mvc;

namespace ticketing_system.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
