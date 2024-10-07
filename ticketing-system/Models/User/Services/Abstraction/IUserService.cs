namespace ticketing_system.Models.User.Services.Abstraction
{
    public interface IUserService
    {
        // Kreiranje novog korisnika
        Task<User> CreateAsync(User user);

        // Ažuriranje starog korisnika po id-u
        Task<User> UpdateAsync(int id, User user);

        // Brisanje korisnika po id-u
        Task DeleteAsync(int id);

        // Dobijanje korisnika na osnovu id-a
        Task<User> GetByIdAsync(int id);

        // Dobijanje korisnika na osnovu username-a i password-a
        Task<User> GetByUsernameAndPasswordAsync(string username, string password);
    }
}
