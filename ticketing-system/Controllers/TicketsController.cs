using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ticketing_system.Models.Group.Services.Abstraction;
using ticketing_system.Models.Ticket.Services.Abstraction;
using ticketing_system.ViewModels.Tickets;

namespace ticketing_system.Controllers
{
    public class TicketsController : Controller
    {
        private readonly IUrgencyService _urgencyService;
        private readonly ITicketTypeService _ticketTypeService;
        private readonly IGroupService _groupService;
        private readonly IStatusService _statusService;

        public TicketsController(
            IUrgencyService urgencyService, 
            ITicketTypeService ticketTypeService, 
            IGroupService groupService, 
            IStatusService statusService
            )
        {
            _urgencyService = urgencyService;
            _ticketTypeService = ticketTypeService;
            _groupService = groupService;
            _statusService = statusService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
