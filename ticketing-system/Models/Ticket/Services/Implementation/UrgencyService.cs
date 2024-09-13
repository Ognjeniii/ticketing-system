using ticketing_system.Models.Ticket.Services.Abstraction;

namespace ticketing_system.Models.Ticket.Services.Implementation
{
    public class UrgencyService : IUrgencyService
    {
        public Task CreateUrgency(Urgency urgency)
        {
            throw new NotImplementedException();
        }

        public Task<List<Urgency>> GetAllUrgencyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Urgency> GetUrgencyByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
