using Microsoft.AspNetCore.Mvc;
using ticketing_system.Models.Ticket;
using ticketing_system.Models.Ticket.Services.Abstraction;

namespace ticketing_system.Controllers
{
    public class AuthController : Controller
    {
        private readonly ITicketService _ticketService;
        public AuthController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public IActionResult Login()
        {
            Ticket ticket = new Ticket
                (
                1,
                DateTime.Now,
                12,
                3,
                "Testiranje",
                "Ovo je neko objašnjenje.",
                new System.Reflection.Metadata.Blob(),
                new DateTime(2025, 1, 1),
                22,
                12,
                43,
                "resenje"
                );

            _ticketService.CreateTicketAsync(ticket);
            return View();
        }
    }
}
