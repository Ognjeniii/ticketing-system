using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ticketing_system.DTO;
using ticketing_system.Models.User.Repositories.Abstraction;

namespace ticketing_system.Models.User.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("***GREŠKA - InvalidOperationException:\n" + ex.Message);
                Console.WriteLine("***STACK TRACE: \n" + ex.StackTrace);
                return null;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("***GREŠKA - SqlException:\n" + ex.Message);
                Console.WriteLine("***STACK TRACE: \n" + ex.StackTrace);
                return null;
            }
        }

        public async Task<User> UpdateAsync(int id, User user)
        {
            var oldUser = await GetByIdAsync(id);
            try
            {
                oldUser.GroupId = user.GroupId;
                oldUser.UserTypeId = user.UserTypeId;
                oldUser.FirstName = user.FirstName;
                oldUser.LastName = user.LastName;
                oldUser.Email = user.Email;
                oldUser.Username = user.Username;
                oldUser.Password = user.Password;
                oldUser.JobTitle = user.JobTitle;
                
                await _context.SaveChangesAsync();

                return oldUser;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("***GREŠKA - DbUpdateConcurrencyException:\n" + ex.Message);
                return null;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("***GREŠKA - DbUpdateException:\n" + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("***GREŠKA - InvalidOperationException:\n" + ex.Message);
                return null;
            }
            catch(SqlException ex)
            {
                Console.WriteLine("***GREŠKA - SqlException:\n" + ex.Message);
                return null;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _context.Users.Where(a => a.UserId == id)
                    .ExecuteDeleteAsync();
            }
            catch (SqlException ex)
            {

                Console.WriteLine("***GREŠKA - SqlException:\n" + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("***GREŠKA - InvalidOperationException:\n" + ex.Message);
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(a => a.UserId == id);

                if (user == null)
                    return null;

                return user;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("***GREŠKA - SqlException:\n" + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("***GREŠKA - InvalidOperationException:\n" + ex.Message);
                return null;
            }
        }

        public async Task<User> GetByUsernameAndPasswordAsync(string username, string password)
        {
            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(a => a.Username == username && a.Password == password);

                if (user == null)
                    return null;

                return user;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("***GREŠKA - SqlException:\n" + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("***GREŠKA - InvalidOperationException:\n" + ex.Message);
                return null;
            }
        }
    }
}
