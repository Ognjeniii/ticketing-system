using Microsoft.AspNetCore.Mvc;
using ticketing_system.Classes;
using ticketing_system.Models.Ticket;
using ticketing_system.Models.Ticket.Services.Abstraction;
using ticketing_system.Models.User;
using ticketing_system.Models.User.Services.Abstraction;

namespace ticketing_system.Controllers
{
    // Ovo je početni kontroler - prvi do kog se dođe prilikom startovanja aplikacije
    public class BaseController : Controller
    {
        private readonly ITicketService _ticketService;

        public BaseController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // Druga metoda po redu koja se pokreće
        public IActionResult Index()
        {
            var cookie = Request.Cookies["RememberMe"];
            var session = HttpContext.Session.GetString("username");

            // Korisnik je prijavlen, šalje se na početni ekran
            if (cookie != null || session != null)
            {
                return RedirectToAction("Home");
            }

            // Korisnik nije prijavljen, šalje se na prijavu
            return RedirectToAction("Index", "Login");
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> Home()
        {
            string user_id = HttpContext.Session.GetString("user_id");

            //Ticket ticket = new Ticket
            //    (
            //        1,
            //        DateTime.Now,
            //        1,
            //        2,
            //        "Prvi tiket",
            //        "Testiranje metode za kreiranje tiketa",
            //        null,
            //        new DateTime(2024, 12, 28),
            //        0, 
            //        0,
            //        1,
            //        null
            //    );

            //await _ticketService.CreateTicketAsync(ticket);


            return View();
        }
    }
}
