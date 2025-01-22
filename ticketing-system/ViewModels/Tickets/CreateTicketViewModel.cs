using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ticketing_system.ViewModels.Tickets
{
    public class CreateTicketViewModel
    {

        [Display(Name = "Urgency")]
        [Required(ErrorMessage = "You must enter the urgency.")]
        public List<SelectListItem> Urgencies { get; set; } // fk
        [Display(Name = "Ticket type")]
        public List<SelectListItem> TicketTypes { get; set; } // fk
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "File")]
        public byte[]? File { get; set; } // Blob?
        [Display(Name = "Group")]
        public List<SelectListItem> Groups { get; set; } // fk

        public int SelectedUrgencyId { get; set; }
        public int SelectedTicketTypeId { get; set; }
        public int SelectedGroupId { get; set; }

        public override string ToString()
        {
            return "Urgency: " + SelectedUrgencyId + "\n" +
                "Ticket type:" + SelectedTicketTypeId + "\n" +
                "Title: " + Title + "\n" +
                "Description: " + Description + "\n" +
                "File: " + File + "\n" +
                "Groups: " + SelectedGroupId + "\n";
        }
    }
}
