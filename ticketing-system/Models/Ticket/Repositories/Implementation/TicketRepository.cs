using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ticketing_system.DTO;
using ticketing_system.Models.Ticket.Repository.Abstraction;
using ticketing_system.Models.User;
using ticketing_system.ViewModels.Tickets;

namespace ticketing_system.Models.Ticket.Repository.Implementation
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public TicketRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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

        public async Task<List<Ticket>> GetByCreator(int userId)
        {
            try
            {
                var tickets = await _context.Tickets
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

        public async Task<List<Ticket>> GetByGroupId(int groupId)
        {
            try
            {
                var tickets = await _context.Tickets
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

        public async Task<List<Ticket>> FilterByStatusAndGroupId(int status, int groupId)
        {
            try
            {
                var tickets = await _context.Tickets
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

        public async Task<List<Ticket>> GetTicketsByExecutor(int userId)
        {
            try
            {
                var tickets = await _context.Tickets
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

        public async Task<List<ListTicketsViewModel>> GetListTicketsViewModel(int groupId)
        {
            var query = @"
                SELECT t.ticket_id, 
                       t.creation_date, 
                       u.description AS urgencydes, 
                       tt.description AS tickettypedes, 
                       t.title, 
                       s.description AS statusdes, 
                       us.username
                FROM tickets t
                JOIN urgencies u ON t.urgency_id = u.urgency_id
                JOIN ticket_types tt ON t.ticket_type_id = tt.ticket_type_id
                JOIN statuses s ON t.status_id = s.status_id
                JOIN users us ON t.executor = us.user_id
                WHERE t.group_id = @GroupId";

            var listTicketsVM = new List<ListTicketsViewModel>();

            try
            {
                string connString = _configuration.GetConnectionString("DefaultConnection");

                using (var conn = new SqlConnection(connString))
                {
                    await conn.OpenAsync();

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@GroupId", groupId);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                listTicketsVM.Add(
                                    new ListTicketsViewModel(
                                        reader.GetInt32(reader.GetOrdinal("ticket_id")),
                                        reader.GetDateTime(reader.GetOrdinal("creation_date")),
                                        reader.GetString(reader.GetOrdinal("urgencydes")),
                                        reader.GetString(reader.GetOrdinal("title")),
                                        reader.GetString(reader.GetOrdinal("tickettypedes")),
                                        reader.GetString(reader.GetOrdinal("username")),
                                        reader.GetString(reader.GetOrdinal("statusdes"))
                                    )
                                );
                            }
                        }
                    }
                }

                return listTicketsVM;
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
