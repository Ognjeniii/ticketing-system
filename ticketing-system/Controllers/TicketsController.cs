using Microsoft.AspNetCore.Mvc;
using ticketing_system.Models.Ticket.Services.Abstraction;

namespace ticketing_system.Controllers
{
    public class TicketsController : Controller
    {
        private readonly IUrgencyService _urgencyService;
        private readonly ITicketTypeService _ticketTypeService;

        public TicketsController(IUrgencyService urgencyService, ITicketTypeService ticketTypeService)
        {
            _urgencyService = urgencyService;
            _ticketTypeService = ticketTypeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateTicketAsync()
        {
            var urgencies = _urgencyService.GetAllAsync();
            var ticketTypes = _ticketTypeService.GetAll(); // GetAllAsync() -- uradi push

            return View();
        }
    }
}
