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
    public class HomeController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IUrgencyService _urgencyService;
        private readonly IUserService _userService;
        private readonly ITicketTypeService _ticketTypeService;
        private readonly IGroupService _groupService;
        private readonly IStatusService _statusService;

        private static User user = null;

        public HomeController(
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

            List<ListTicketsViewModel> ticketViewModelList = await _ticketService.GetVMByGroupAsync(groupId);

            return View("~/Views/Home/Home.cshtml", ticketViewModelList);
        }

        [HttpGet]
        public async Task<IActionResult> FilterTickets(string filter)
        {
            List<ListTicketsViewModel> tickets = new List<ListTicketsViewModel>();

            if (filter == "all") // all tickets assigned to my group which don't have the status finished
            {
                tickets = await _ticketService.GetVMByGroupAsync(user.GroupId);
            }
            else if (filter == "open") // unassigned tickets - assigned to my group
            {
                tickets = await _ticketService.GetVMByStatusAndGroupAsync(4, user.GroupId);
            }
            else if (filter == "assigned") // tickets assigned to me, and not finished
            {
                tickets = await _ticketService.GetVMByExecutorAsync(user.UserId);
            }
            else if (filter == "waiting") // tickets on waiting
            {
                tickets = await _ticketService.GetVMByStatusAndGroupAsync(3, user.GroupId);
            }
            else if (filter == "finished") // closed tickets (top 100)?
            {
                tickets = await _ticketService.GetVMByStatusAndGroupAsync(2, user.GroupId);
            }

            return PartialView("~/Views/Home/_TicketListPartial.cshtml", tickets);
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

            return PartialView("~/Views/Home/_CreateTicketPartial.cshtml", model);
        }
    }
}
