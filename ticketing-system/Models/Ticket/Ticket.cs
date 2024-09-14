using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace ticketing_system.Models.Ticket
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; } // pk
        public int CreatedBy { get; set; } // fk 
        public DateTime CreatedDate { get; set; }
        public int UrgencyId { get; set; } // fk
        public int TicketTypeId { get; set; } // fk
        public string Title { get; set; }   
        public string Description { get; set; }
        public string? File { get; set; } // Blob?
        public DateTime FinishigDate { get; set; }
        public int Executor { get; set; } // fk
        public int GroupId { get; set; } // fk
        public int StatusId { get; set; } // fk
        public string? SolutionDes { get; set; }
            
        public Ticket
            (
            int createdBy,
            DateTime createdDate,
            int urgencyId,
            int ticketTypeId,
            string title,
            string description,
            string file, 
            DateTime finishigDate,
            int executor,
            int groupId,
            int statusId,
            string? solutionDes
            )
        {
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            UrgencyId = urgencyId;
            TicketTypeId = ticketTypeId;
            Title = title;
            Description = description;
            File = file;
            FinishigDate = finishigDate;
            Executor = executor;
            GroupId = groupId;
            StatusId = statusId;
            SolutionDes = solutionDes;
        }
    }
}
