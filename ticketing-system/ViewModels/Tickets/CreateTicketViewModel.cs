using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ticketing_system.ViewModels.Tickets
{
    public class CreateTicketViewModel
    {

        [Display(Name = "Urgency")]
        [Required(ErrorMessage = "You must enter the urgency.")]
        public List<SelectListItem> UrgencyId { get; set; } // fk
        public List<SelectListItem> TicketTypeId { get; set; } // fk
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[]? File { get; set; } // Blob?
        // public DateTime? FinishingDate { get; set; }
        // public int? Executor { get; set; } // fk
        public List<SelectListItem> GroupId { get; set; } // fk
        public List<SelectListItem> StatusId { get; set; } // fk
    }
}
