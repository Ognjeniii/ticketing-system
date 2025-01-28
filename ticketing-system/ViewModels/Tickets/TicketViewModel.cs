using System.Text.RegularExpressions;
using ticketing_system.Models.Ticket;
using ticketing_system.Models.User;

namespace ticketing_system.ViewModels.Tickets
{
    public class TicketViewModel
    {
        public int TicketId { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public Urgency Urgency { get; set; }
        public TicketType TicketType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[]? File { get; set; }
        public DateTime? FinishingDate { get; set; }
        public User Executor { get; set; }
        public Group Group { get; set; }
        public Status Status { get; set; }
        public string? SolutionDes { get; set; }

    }
}
