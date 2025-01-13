using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using ticketing_system.Classes;
using ticketing_system.Models.Ticket;
using ticketing_system.Models.Ticket.Services.Abstraction;
using ticketing_system.Models.User;
using ticketing_system.Models.User.Repositories.Abstraction;
using ticketing_system.Models.User.Services.Abstraction;

namespace ticketing_system.Controllers
{
    // Ovo je početni kontroler - prvi do kog se dođe prilikom startovanja aplikacije
    public class BaseController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IUrgencyService _urgencyService;
        private readonly IUserService _userService;

        public BaseController(ITicketService ticketService, IUrgencyService urgencyService, IUserService userService)
        {
            _ticketService = ticketService;
            _urgencyService = urgencyService;
            _userService = userService;
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
            string user_id = Request.Cookies["UserId"];
            User user = await _userService.GetUserByIdAsync(Int32.Parse(user_id));

            int groupId = user.GroupId;
            List<Ticket> tickets = await _ticketService.GetByGroupIdAsync(groupId);

            return View(tickets);
        }
    }
}
