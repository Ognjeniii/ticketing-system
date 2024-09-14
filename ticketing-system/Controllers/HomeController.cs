using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ticketing_system.Models;
using ticketing_system.Models.Ticket;
using ticketing_system.Models.Ticket.Services.Abstraction;

namespace ticketing_system.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITicketService _ticketService;

        public HomeController(ILogger<HomeController> logger, ITicketService ticketService)
        {
            _logger = logger;
            _ticketService = ticketService;
        }

        public IActionResult Index()
        {
            Console.WriteLine("Dodavanje novog korisnika");

            Ticket ticket = new Ticket
                (1,
                DateTime.Now,
                12,
                3,
                "Testiranje",
                "Ovo je neko objašnjenje.",
                "",
                new DateTime(2025, 1, 1),
                22,
                12,
                43,
                "resenje"
                );

            _ticketService.CreateTicketAsync( ticket );

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
