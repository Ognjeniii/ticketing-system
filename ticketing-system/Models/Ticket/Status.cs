using System.ComponentModel.DataAnnotations.Schema;

namespace ticketing_system.Models.Ticket
{
    [Table("statuses")]
    public class Status
    {
        [Column("status_id")]
        public int StatusId { get; }
        [Column("description")]
        public string Description { get; set; }
    }
}
