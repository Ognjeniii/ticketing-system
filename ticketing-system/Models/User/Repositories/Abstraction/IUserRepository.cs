namespace ticketing_system.Models.User.Repositories.Abstraction
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<User> DeleteAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task<User> GetByNameAndPasswordAsync(string name, string password);
    }
}
