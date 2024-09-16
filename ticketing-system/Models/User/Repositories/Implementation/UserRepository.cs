using ticketing_system.Models.User.Repositories.Abstraction;

namespace ticketing_system.Models.User.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        public Task<User> CreateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByNameAndPasswordAsync(string name, string password)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
