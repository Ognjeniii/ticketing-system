using ticketing_system.Models.Ticket.Repository.Abstraction;
using ticketing_system.Models.Ticket.Services.Abstraction;

namespace ticketing_system.Models.Ticket.Services.Implementation
{
    public class UrgencyService : IUrgencyService
    {
        private readonly IUrgencyRepository _urgencyRepository;
        public UrgencyService(IUrgencyRepository urgencyRepository)
        {
            _urgencyRepository = urgencyRepository;
        }
        public async Task CreateAsync(Urgency urgency)
        {
            await _urgencyRepository.Create(urgency);
        }

        public async Task<List<Urgency>> GetAllAsync()
        {
            return await _urgencyRepository.GetAll();
        }

        public async Task<Urgency> GetByIdAsync(int id)
        {
            return await _urgencyRepository.GetById(id);
        }
    }
}
