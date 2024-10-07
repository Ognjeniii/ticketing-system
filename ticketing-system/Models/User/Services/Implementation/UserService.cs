using ticketing_system.Models.User.Repositories.Abstraction;
using ticketing_system.Models.User.Services.Abstraction;

namespace ticketing_system.Models.User.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateAsync(User user)
        {
            return await _userRepository.CreateAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetByUsernameAndPasswordAsync(string username, string password)
        {
            return await _userRepository.GetByUsernameAndPasswordAsync(username, password);
        }

        public async Task<User> UpdateAsync(int id, User user)
        {
            return await _userRepository.UpdateAsync(id, user);
        }
    }
}
