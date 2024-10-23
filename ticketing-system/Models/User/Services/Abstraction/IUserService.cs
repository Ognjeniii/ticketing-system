namespace ticketing_system.Models.User.Services.Abstraction
{
    public interface IUserService
    {
        // Kreiranje novog korisnika
        Task<User> CreateUserAsync(User user);

        // Ažuriranje starog korisnika po id-u
        Task<User> UpdateUserAsync(User user);

        // Brisanje korisnika po id-u
        Task DeleteUserAsync(int id);

        // Dobijanje korisnika na osnovu id-a
        Task<User> GetUserByIdAsync(int id);

        // Dobijanje korisnika na osnovu username-a i password-a
        Task<User> GetUserByUsernameAndPasswordAsync(string username, string password);

        // Dobijanje korisnika po email-u
        Task<User> GetUserByEmailAsync(string email);
    }
}
