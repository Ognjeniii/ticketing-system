using System.ComponentModel.DataAnnotations.Schema;

namespace ticketing_system.Models.Ticket
{
    [Table("urgencies")]
    public class Urgency
    {
        [Column("urgency_id")]
        public int UrgencyId { get; set; } // pk
        [Column("description")]
        public string Description { get; set; }

        public Urgency(string description)
        {
            Description = description;
        }
    }
}
