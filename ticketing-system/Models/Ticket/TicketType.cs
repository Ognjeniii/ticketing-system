using System.ComponentModel.DataAnnotations.Schema;

namespace ticketing_system.Models.Ticket
{
    [Table("ticket_types")]
    public class TicketType
    {
        [Column("ticket_type_id")]
        public int TicketTypeId { get; }
        public string Description { get; set; }
    }
}
