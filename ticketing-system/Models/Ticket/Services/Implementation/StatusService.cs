using ticketing_system.Models.Ticket.Repositories.Abstraction;
using ticketing_system.Models.Ticket.Services.Abstraction;

namespace ticketing_system.Models.Ticket.Services.Implementation
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }
        public Task CreateAsync(Status status)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Status>> GetAllAsync()
        {
            return await _statusRepository.GetAll();
        }

        public Task<Status> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
