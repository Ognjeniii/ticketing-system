namespace ticketing_system.Models.Ticket
{
    public class TicketType
    {
        public int TicketTypeId { get; }
        public string Description { get; set; }

        public TicketType(string description) 
        {
            Description = description;
        }
    }
}
