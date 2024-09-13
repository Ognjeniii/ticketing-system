using ticketing_system.DTO;
using ticketing_system.Models.Ticket.Repository.Abstraction;

namespace ticketing_system.Models.Ticket.Repository.Implementation
{
    public class TicketRepository : ITicketRepostiroy
    {
        public Task<Ticket> Create(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
