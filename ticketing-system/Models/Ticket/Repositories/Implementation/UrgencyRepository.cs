using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Urgency>> GetAll()
        {
            try
            {
                var urgencies = await _context.Urgencies.ToListAsync();
                return urgencies;
            }
            catch (Exception ex)
            {
                Console.WriteLine("***ERROR: " + ex.Message);
                Console.WriteLine("***STACK TRACE: " + ex.StackTrace);
                return null;
            }
        }

        public async Task<Urgency> GetById(int id)
        {
            try
            {
                var urgency = await _context.Urgencies
                    .FirstOrDefaultAsync(u => u.UrgencyId == id);

                if (urgency == null)
                    return null;

                return urgency;
            }
            catch (Exception ex)
            {
                Console.WriteLine("***ERROR: " + ex.Message);
                Console.WriteLine("***STACK TRACE: " + ex.StackTrace);
                return null;
            }
        }
    }
}
