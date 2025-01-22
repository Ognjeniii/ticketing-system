using Microsoft.AspNetCore.Mvc;
using ticketing_system.Models.Group.Services.Abstraction;
using ticketing_system.Models.Ticket;
using ticketing_system.Models.Ticket.Services.Abstraction;
using ticketing_system.ViewModels.Tickets;

namespace ticketing_system.Controllers
{
    public class TicketController : Controller
    {
        private readonly IUrgencyService _urgencyService;
        private readonly ITicketTypeService _ticketTypeService;
        private readonly IGroupService _groupService;
        private readonly IStatusService _statusService;
        private readonly ITicketService _ticketService;

        public TicketController(
            IUrgencyService urgencyService,
            ITicketTypeService ticketTypeService,
            IGroupService groupService,
            IStatusService statusService,
            ITicketService ticketService
            )
        {
            _urgencyService = urgencyService;
            _ticketTypeService = ticketTypeService;
            _groupService = groupService;
            _statusService = statusService;
            _ticketService = ticketService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(CreateTicketViewModel model)
        {
            Ticket ticket = new Ticket();
            int userId = Int32.Parse(Request.Cookies["UserId"]);

            ticket.CreatedBy = userId;
            ticket.CreationDate = DateTime.Now;

            ticket.UrgencyId = model.SelectedUrgencyId;
            ticket.TicketTypeId = model.SelectedTicketTypeId;
            ticket.Title = model.Title;
            ticket.Description = model.Description;
            ticket.File = model.File;
            ticket.GroupId = model.SelectedGroupId;

            await _ticketService.CreateAsync(ticket);

            return RedirectToAction("Home", "Home");
        }
    }
}
