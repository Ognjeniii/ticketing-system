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

        public async Task<IActionResult> CreateTicketViewModelAsync()
        {
            var urgencies = await _urgencyService.GetAllAsync();
            var ticketTypes = await _ticketTypeService.GetAllAsync();
            var groups = await _groupService.GetAllAsync();
            var statuses = await _statusService.GetAllAsync();

            var model = new CreateTicketViewModel()
            {
                Urgencies = urgencies.Select(u => new SelectListItem
                {
                    Value = u.UrgencyId.ToString(),
                    Text = u.Description
                }).ToList(),
                TicketTypes = ticketTypes.Select(tt => new SelectListItem
                {
                    Value = tt.TicketTypeId.ToString(),
                    Text = tt.Description
                }).ToList(),
                Groups = groups.Select(g => new SelectListItem
                {
                    Value = g.GroupId.ToString(),
                    Text = g.Name
                }).ToList()
            };

            return PartialView("~/Views/Base/_CreateTicketPartial.cshtml");
        }
    }
}
