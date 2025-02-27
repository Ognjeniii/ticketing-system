using System.ComponentModel.DataAnnotations.Schema;

namespace ticketing_system.ViewModels.Tickets
{
    public class ListTicketsViewModel
    {
        public int TicketId { get; set; }
        public DateTime CreationDate { get; set; }
        public string UrgencyDes { get; set; } 
        public string TicketTypeDesc { get; set; } 
        public string Title { get; set; }
        public string? Executor { get; set; }
        public string Status { get; set; }

        public ListTicketsViewModel()
        {

        }

        public ListTicketsViewModel(
            int ticketId,
            DateTime creationDate,
            string urgencyDes,
            string ticketTypeDesc,
            string title,
            string executor,
            string status
            )
        {
            TicketId = ticketId;
            CreationDate = creationDate;
            UrgencyDes = urgencyDes;
            TicketTypeDesc = ticketTypeDesc;
            Title = title;
            Executor = executor;
            Status = status;
        }
    }
}
