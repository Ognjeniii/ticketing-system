using ticketing_system.Models.Ticket.Services.Abstraction;

namespace ticketing_system.Models.Ticket.Services.Implementation
{
    public class TicketService : ITicketService
    {
        public Task CreateTicketAsync(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> GetTicketById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
