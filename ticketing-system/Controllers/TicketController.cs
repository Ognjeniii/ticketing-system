using Microsoft.AspNetCore.Mvc;
using ticketing_system.Models.Group.Services.Abstraction;
using ticketing_system.Models.Ticket;
using ticketing_system.Models.Ticket.Services.Abstraction;
using ticketing_system.Models.User;
using ticketing_system.Models.User.Services.Abstraction;
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
        private readonly IUserService _userService;

        public TicketController(
            IUrgencyService urgencyService,
            ITicketTypeService ticketTypeService,
            IGroupService groupService,
            IStatusService statusService,
            ITicketService ticketService,
            IUserService userService
            )
        {
            _urgencyService = urgencyService;
            _ticketTypeService = ticketTypeService;
            _groupService = groupService;
            _statusService = statusService;
            _ticketService = ticketService;
            _userService = userService;
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

            if (model.File != null && model.File.Length > 0)
            {
                if (model.File.Length > 20971520)
                {
                    ModelState.AddModelError("File", "The uploaded file exceeds the size limit of 20 MB.");
                    return View(model); // ovde treba izmena
                }

                using (var memoryStream = new MemoryStream())
                {
                    await model.File.CopyToAsync(memoryStream);
                    byte[] fileData = memoryStream.ToArray();

                    ticket.File = fileData;
                }
            }

            ticket.GroupId = model.SelectedGroupId;

            ticket.StatusId = 4;

            await _ticketService.CreateAsync(ticket);

            return RedirectToAction("Home", "Home");
        }

        public async Task<IActionResult> SearchTicket(SearchTicketViewModel model)
        {
            if (model.CreatedBy != null)
            {
                User creator = await _userService.GetByUsernameAsync(model.CreatedBy);
                model.CreatedByUserId = creator.UserId;
            }

            if (model.Executor != null)
            {
                User executor = await _userService.GetByUsernameAsync(model.Executor);
                model.ExecutorUserId = executor.UserId;
            }

            List<ListTicketsViewModel> tickets = await _ticketService.SearchTicketsAsync(model);

            return RedirectToAction("Home", "Home");
        }
    }
}
