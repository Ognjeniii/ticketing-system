﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
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
            string userSession = HttpContext.Session.GetString("user_object");
            User user = JsonSerializer.Deserialize<User>(userSession);

            ticket.CreatedBy = user.UserId;
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

        public async Task<IActionResult> SearchTicket(SearchTicketViewModelComposite model)
        {
            if (model.searchTicketViewModel.CreatedBy != null)
            {
                User creator = await _userService.GetByUsernameAsync(model.searchTicketViewModel.CreatedBy);
                model.searchTicketViewModel.CreatedByUserId = creator.UserId;
            }

            if (model.searchTicketViewModel.Executor != null)
            {
                User executor = await _userService.GetByUsernameAsync(model.searchTicketViewModel.Executor);
                model.searchTicketViewModel.ExecutorUserId = executor.UserId;
            }

            List<ListTicketsViewModel> tickets = await _ticketService.SearchTicketsAsync(model);
            model.listTicketsViewModel = tickets;

            return PartialView("_TicketTablePartial", model.listTicketsViewModel);
        }
    }
}
