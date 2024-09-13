namespace ticketing_system.Models.Ticket
{
    public class Urgency
    {
        public int UrgencyId { get; set; } // pk
        public string Description { get; set; }

        public Urgency(string description)
        {
            Description = description;
        }
    }
}
