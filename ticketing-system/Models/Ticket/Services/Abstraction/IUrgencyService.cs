namespace ticketing_system.Models.Ticket.Services.Abstraction
{
    public interface IUrgencyService
    {
        Task CreateAsync(Urgency urgency);
        Task<List<Urgency>> GetAllAsync();
        Task<Urgency> GetByIdAsync(int id);
    }
}
