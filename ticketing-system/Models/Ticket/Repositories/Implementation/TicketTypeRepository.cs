using Microsoft.EntityFrameworkCore;
using ticketing_system.DTO;
using ticketing_system.Models.Ticket.Repositories.Abstraction;

namespace ticketing_system.Models.Ticket.Repositories.Implementation
{
    public class TicketTypeRepository : ITicketTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public TicketTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(TicketType ticketType)
        {
            try
            {
                _context.TicketTypes.Add(ticketType);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("***ERROR: " + ex.Message);
                Console.WriteLine("***STACK TRACE: " + ex.StackTrace);
            }
        }

        public async Task<List<TicketType>> GetAllAsync()
        {
            try
            {
                var ticketTypes = await _context.TicketTypes
                    .ToListAsync();
                
                if (ticketTypes == null)
                    return null;

                return ticketTypes;
            }
            catch (Exception ex)
            {
                Console.WriteLine("***ERROR: " + ex.Message);
                Console.WriteLine("***STACK TRACE: " + ex.StackTrace);
                return null;
            }
        }

        public async Task<TicketType> GetByIdAsync(int id)
        {
            try
            {
                var ticketType = await _context.TicketTypes
                    .FirstOrDefaultAsync(u => u.TicketTypeId == id);

                if (ticketType == null)
                    return null;

                return ticketType;
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
