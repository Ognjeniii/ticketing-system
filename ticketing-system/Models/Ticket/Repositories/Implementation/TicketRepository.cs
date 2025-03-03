using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text;
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

        public async Task<List<ListTicketsViewModel>> GetVMByGroup(int groupId)
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
                LEFT JOIN users us ON t.executor = us.user_id
                WHERE t.group_id = @GroupId
                AND t.status_id != 2";

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
                                        reader.IsDBNull(reader.GetOrdinal("username")) ? null : reader.GetString(reader.GetOrdinal("username")),
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

        public async Task<List<ListTicketsViewModel>> GetVMByStatusAndGroup(int statusId, int groupId)
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
                LEFT JOIN users us ON t.executor = us.user_id
                WHERE t.group_id = @GroupId 
                AND t.status_id = @StatusId";

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
                        cmd.Parameters.AddWithValue("@StatusId", statusId);

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
                                        reader.IsDBNull(reader.GetOrdinal("username")) ? null : reader.GetString(reader.GetOrdinal("username")),
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

        public async Task<List<ListTicketsViewModel>> GetVMByExecutor(int userId)
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
                LEFT JOIN users us ON t.executor = us.user_id
                WHERE t.executor = @Executor 
                AND t.status_id != 2";

            var listTicketsVM = new List<ListTicketsViewModel>();
            string connString = _configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (var conn = new SqlConnection(connString))
                {
                    await conn.OpenAsync();

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Executor", userId);

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
                                        reader.IsDBNull(reader.GetOrdinal("username")) ? null : reader.GetString(reader.GetOrdinal("username")),
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

        public async Task<List<ListTicketsViewModel>> SearchTicket(SearchTicketViewModelComposite ticket)
        {
            string connString = _configuration.GetConnectionString("DefaultConnection");
            List<ListTicketsViewModel> listTicketsVM = new List<ListTicketsViewModel>();

            try
            {
                using (var connection = new SqlConnection(connString))
                {
                    await connection.OpenAsync();

                    var sql = new StringBuilder(@"
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
                    LEFT JOIN users us ON t.executor = us.user_id
                    WHERE 1=1");

                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;

                        if (ticket.searchTicketViewModel.TicketId.HasValue)
                        {
                            sql.Append(" AND t.ticket_id = @TicketId");
                            command.Parameters.AddWithValue("@TicketId", ticket.searchTicketViewModel.TicketId);
                        }

                        if (ticket.searchTicketViewModel.CreatedByUserId.HasValue)
                        {
                            sql.Append(" AND t.created_by = @CreatedBy");
                            command.Parameters.AddWithValue("@CreatedBy", ticket.searchTicketViewModel.CreatedByUserId);
                        }

                        if (ticket.searchTicketViewModel.CreationDate.HasValue)
                        {
                            sql.Append(" AND t.creation_date = @CreationDate");
                            command.Parameters.AddWithValue("@CreationDate", ticket.searchTicketViewModel.CreationDate);
                        }

                        if (ticket.searchTicketViewModel.SelectedTicketTypeId.HasValue)
                        {
                            sql.Append(" AND t.ticket_type_id = @TicketTypeId");
                            command.Parameters.AddWithValue("@TicketTypeId", ticket.searchTicketViewModel.SelectedTicketTypeId);
                        }

                        if (ticket.searchTicketViewModel.FinishingDate.HasValue)
                        {
                            sql.Append(" AND t.finishing_date = @FinishingDate");
                            command.Parameters.AddWithValue("@FinishingDate", ticket.searchTicketViewModel.FinishingDate);
                        }

                        if (ticket.searchTicketViewModel.ExecutorUserId.HasValue)
                        {
                            sql.Append(" AND t.executor = @ExecutorId");
                            command.Parameters.AddWithValue("@ExecutorId", ticket.searchTicketViewModel.ExecutorUserId);
                        }

                        if (ticket.searchTicketViewModel.SelectedGroupId.HasValue)
                        {
                            sql.Append(" AND t.group_id = @GroupId");
                            command.Parameters.AddWithValue("@GroupId", ticket.searchTicketViewModel.SelectedGroupId);
                        }

                        sql.Append(" ORDER BY t.creation_date DESC");

                        command.CommandText = sql.ToString();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
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
                                        reader.IsDBNull(reader.GetOrdinal("username")) ? null : reader.GetString(reader.GetOrdinal("username")),
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

        public async Task<List<ListTicketsViewModel>> GetVMByCreator(int userId)
        {
            var query = @"
                SELECT top (30)
                       t.ticket_id, 
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
                LEFT JOIN users us ON t.executor = us.user_id
                WHERE t.created_by = @CreatedBy";

            var listTicketsVM = new List<ListTicketsViewModel>();
            string connString = _configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (var conn = new SqlConnection(connString))
                {
                    await conn.OpenAsync();

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CreatedBy", userId);

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
                                        reader.IsDBNull(reader.GetOrdinal("username")) ? null : reader.GetString(reader.GetOrdinal("username")),
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
