using ticketing_system.DTO;
using ticketing_system.Models.Ticket.Repository.Abstraction;

namespace ticketing_system.Models.Ticket.Repository.Implementation
{
    public class UrgencyRepository : IUrgencyRepository
    {
        private readonly ApplicationDbContext _context;
        public UrgencyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(Urgency urgency)
        {
            try
            {
                _context.Urgencies.Add(urgency);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("***ERROR: " + ex.Message);
                Console.WriteLine("***STACK TRACE: " + ex.StackTrace);
            }
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
