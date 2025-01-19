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
        public List<SelectListItem> TicketTypes { get; set; } // fk
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[]? File { get; set; } // Blob?
        // public DateTime? FinishingDate { get; set; }
        // public int? Executor { get; set; } // fk
        public List<SelectListItem> Groups { get; set; } // fk
        public List<SelectListItem> Statuses { get; set; } // fk


    }
}
