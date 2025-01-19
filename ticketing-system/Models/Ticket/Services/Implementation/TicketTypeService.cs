using ticketing_system.Models.Ticket.Repositories.Abstraction;

namespace ticketing_system.Models.Ticket.Services.Implementation
{
    public class TicketTypeService : ITicketTypeRepository
    {
        private readonly ITicketTypeRepository _ticketTypeRepository;
        public TicketTypeService(ITicketTypeRepository ticketTypeRepository)
        {
            _ticketTypeRepository = ticketTypeRepository;
        }

        public async Task CreateAsync(TicketType ticketType)
        {
            await _ticketTypeRepository.CreateAsync(ticketType);
        }

        public async Task<List<TicketType>> GetAllAsync()
        {
            return await _ticketTypeRepository.GetAllAsync();
        }

        public async Task<TicketType> GetByIdAsync(int id)
        {
            return await _ticketTypeRepository.GetByIdAsync(id);
        }
    }
}
