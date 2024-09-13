using ticketing_system.Models.Ticket.Repository.Abstraction;

namespace ticketing_system.Models.Ticket.Repository.Implementation
{
    public class UrgencyRepository : IUrgencyRepository
    {
        public Task Create(Urgency urgency)
        {
            throw new NotImplementedException();
        }

        public Task<List<Urgency>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Urgency> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
