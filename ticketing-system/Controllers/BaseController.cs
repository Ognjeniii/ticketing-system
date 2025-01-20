using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;
using ticketing_system.Classes;
using ticketing_system.Models.Group.Services.Abstraction;
using ticketing_system.Models.Ticket;
using ticketing_system.Models.Ticket.Services.Abstraction;
using ticketing_system.Models.Ticket.Services.Implementation;
using ticketing_system.Models.User;
using ticketing_system.Models.User.Repositories.Abstraction;
using ticketing_system.Models.User.Services.Abstraction;
using ticketing_system.ViewModels.Tickets;

namespace ticketing_system.Controllers
{
    // Ovo je početni kontroler - prvi do kog se dođe prilikom startovanja aplikacije
    public class BaseController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IUrgencyService _urgencyService;
        private readonly IUserService _userService;
        private readonly ITicketTypeService _ticketTypeService;
        private readonly IGroupService _groupService;
        private readonly IStatusService _statusService;

        private static User user = null;

        public BaseController(
            ITicketService ticketService, 
            IUrgencyService urgencyService, 
            IUserService userService,
            ITicketTypeService ticketTypeService, 
            IGroupService groupService, 
            IStatusService statusService
            )
        {
            _ticketService = ticketService;
            _urgencyService = urgencyService;
            _userService = userService;
            _ticketTypeService = ticketTypeService;
            _groupService = groupService;
            _statusService = statusService;
        }

        // Druga metoda po redu koja se pokreće
        public IActionResult Index()
        {
            var cookie = Request.Cookies["RememberMe"];
            var userIdCookie = Request.Cookies["UserId"];
            var session = HttpContext.Session.GetString("username");

            // kada se neko prijavio pre pet dana, ostaje mu samo cookie, bez podatka o tome koji je
            // user u pitanju. Tj. nemamo user_id
            // dodao sam user id za cookie, OBAVEZNO PREGLEDATI CEO TOK OD POCETKA DO KRAJA!!!

            // Korisnik je prijavlen, šalje se na početni ekran
            if (cookie != null || session != null || userIdCookie != null)
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

        // Metoda kojom se prebacujemo na početnu str. ako je korisnik prijavljen, i kojom se listaju tiketi
        public async Task<IActionResult> Home()
        {
            string userId = Request.Cookies["UserId"];
            user = await _userService.GetUserByIdAsync(Int32.Parse(userId));

            int groupId = user.GroupId;
            List<Ticket> tickets = await _ticketService.GetByGroupIdAsync(groupId);

            return View(tickets);
        }

        [HttpGet]
        public async Task<IActionResult> FilterTickets(string filter)
        {
            List<Ticket> tickets = new List<Ticket>();
            
            if (filter == "open") // nedodeljeni tiketi
            {
                tickets = await _ticketService.FilterByStatusAndGroupIdAsync(4, user.GroupId);
            }
            else if (filter == "assigned") // dodeljeni tiketi
            {
                tickets = await _ticketService.GetAssignedTicketsByGroupId(user.GroupId);   
            }
            else if (filter == "inProgress") // tiketu koji su u toku
            {
                tickets = await _ticketService.FilterByStatusAndGroupIdAsync(1, user.GroupId);
            }
            else if (filter == "waiting") // tiketi na čekanju
            {
                tickets = await _ticketService.FilterByStatusAndGroupIdAsync(3, user.GroupId);
            }
            else if (filter == "finished") // zatvoreni tiketi
            {
                tickets = await _ticketService.FilterByStatusAndGroupIdAsync(2, user.GroupId);
            }

            return PartialView("~/Views/Base/_TicketListPartial.cshtml", tickets);
        }

        [HttpGet]
        public async Task<IActionResult> GetCreateTicketForm()
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

            return PartialView("~/Views/Base/_CreateTicketPartial.cshtml", model);
        }
    }
}
