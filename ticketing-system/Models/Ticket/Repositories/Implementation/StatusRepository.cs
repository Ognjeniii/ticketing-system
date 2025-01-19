using Microsoft.EntityFrameworkCore;
using ticketing_system.DTO;
using ticketing_system.Models.Ticket.Repositories.Abstraction;

namespace ticketing_system.Models.Ticket.Repositories.Implementation
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ApplicationDbContext _context;
        public StatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task Create(Status status)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Status>> GetAll()
        {
            return await _context.Statuses.ToListAsync();
        }

        public Task<Status> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
