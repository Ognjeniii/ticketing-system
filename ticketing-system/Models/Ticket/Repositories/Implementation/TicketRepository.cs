using Microsoft.EntityFrameworkCore;
using ticketing_system.DTO;
using ticketing_system.Models.Ticket.Repository.Abstraction;
using ticketing_system.Models.User;

namespace ticketing_system.Models.Ticket.Repository.Implementation
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;
        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Ticket ticket)
        {
            try
            {
                _context.Tickets.Add(ticket);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("***ERROR: " + ex.Message);
                Console.WriteLine("***STACK TRACE: " + ex.StackTrace);
            }
        }

        public async Task<Ticket> GetById(int id)
        {
            try
            {
                var ticket = await _context.Tickets
                    .FirstOrDefaultAsync(u => u.TicketId == id);

                if (ticket == null)
                    return null;    

                return ticket;
            }
            catch (Exception ex)
            {
                Console.WriteLine("***ERROR: " + ex.Message);
                Console.WriteLine("***STACK TRACE: " + ex.StackTrace);
                return null;
            }
        }

        public Task<List<Ticket>> GetByCreator(int userId)
        {
            try
            {
                var tickets = _context.Tickets
                    .Where(u => u.CreatedBy == userId)
                    .ToListAsync();

                return tickets;
            }
            catch (Exception ex)
            {
                Console.WriteLine("***ERROR: " + ex.Message);
                Console.WriteLine("***STACK TRACE: " + ex.StackTrace);
                return null;
            }
        }

        public Task<List<Ticket>> GetByGroupId(int groupId)
        {
            try
            {
                var tickets = _context.Tickets
                    .Where(u => u.GroupId == groupId)
                    .ToListAsync();

                return tickets;
            }
            catch (Exception ex)
            {
                Console.WriteLine("***ERROR: " + ex.Message);
                Console.WriteLine("***STACK TRACE: " + ex.StackTrace);
                return null;
            }
        }

        public Task<List<Ticket>> FilterByStatusAndGroupId(int status, int groupId)
        {
            try
            {
                var tickets = _context.Tickets
                    .Where(u => u.StatusId == status
                             && u.GroupId == groupId)
                    .ToListAsync();

                return tickets;
            }
            catch (Exception ex)
            {
                Console.WriteLine("***ERROR: " + ex.Message);
                Console.WriteLine("***STACK TRACE: " + ex.StackTrace);
                return null;
            }
        }

        public Task<List<Ticket>> GetTicketsByExecutor(int userId)
        {
            try
            {
                var tickets = _context.Tickets
                    .Where(u => u.Executor == userId)
                    .ToListAsync();

                return tickets;
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
