namespace ticketing_system.Models.User.Services.Abstraction
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);    
    }
}
