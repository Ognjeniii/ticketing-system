using Microsoft.AspNetCore.Mvc.Rendering;

namespace ticketing_system.ViewModels.Tickets
{
    public class SearchTicketViewModel
    {
        public int? TicketId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public List<SelectListItem> TicketTypes { get; set; }
        public DateTime? FinishingDate { get; set; }
        public string? Executor { get; set; }
        public List<SelectListItem> Groups { get; set; }

        public int? SelectedTicketTypeId { get; set; }
        public int? SelectedGroupId { get; set; }

        public override string ToString()
        {
            return TicketId.ToString() + ", " + CreatedBy + ", " + CreationDate.ToString() + ", ";
        }

    }
}
