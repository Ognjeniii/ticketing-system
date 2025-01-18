using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace ticketing_system.Models.Ticket
{
    [Table("tickets")]
    public class Ticket
    {
        [Column("ticket_id")]
        public int TicketId { get; } // pk
        [Column("created_by")]
        public int CreatedBy { get; set; } // fk user_id
        [Column("creation_date")]
        public DateTime CreationDate { get; set; }
        [Column("urgency_id")]
        public int UrgencyId { get; set; } // fk
        [Column("ticket_type_id")]
        public int TicketTypeId { get; set; } // fk
        [Column("title")]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("file")]
        public byte[]? File { get; set; } // Blob?
        [Column("finishing_date")]
        public DateTime? FinishingDate { get; set; }
        [Column("executor")]
        public int? Executor { get; set; } // fk
        [Column("group_id")]
        public int? GroupId { get; set; } // fk
        [Column("status_id")]
        public int? StatusId { get; set; } // fk

        // Trebalo bi da imam comments tabelu, gde će svaki red predstavljati neki komentar, 
        // takođe svaki red ima ticket_id, na koji se komentar odnosi.

        [Column("solution_des")]
        public string? SolutionDes { get; set; }

        public Ticket()
        {

        }

        public Ticket
            (
            int ticketId,
            int createdBy,
            DateTime creationDate,
            int urgencyId,
            int ticketTypeId,
            string title,
            string description,
            byte[] file,
            DateTime finishingDate,
            int executor,
            int groupId,
            int statusId,
            string? solutionDes
            )
        {
            TicketId = ticketId;
            CreatedBy = createdBy;
            CreationDate = creationDate;
            UrgencyId = urgencyId;
            TicketTypeId = ticketTypeId;
            Title = title;
            Description = description;
            File = file;
            FinishingDate = finishingDate;
            Executor = executor;
            GroupId = groupId;
            StatusId = statusId;
            SolutionDes = solutionDes;
        }

        public override string ToString()
        {
            return "Ticket id: " + TicketId + "\n" +
                   "Created by: " + CreatedBy + "\n" +
                   "Cration date: " + CreationDate + "\n" +
                   "Urgency id: " + UrgencyId + "\n" +
                   "Ticket type id: " + TicketTypeId + "\n" +
                   "Title: " + Title + "\n" +
                   "Description: " + Description + "\n" +
                   "File: " + File + "\n" +
                   "Finishing date: " + FinishingDate + "\n" +
                   "Executor: " + Executor + "\n" +
                   "Group id: " + GroupId + "\n" +
                   "Status id: " + StatusId + "\n" +
                   "Solution description: " + SolutionDes + "\n" +
                   "=============================================";
        } 
    }
}