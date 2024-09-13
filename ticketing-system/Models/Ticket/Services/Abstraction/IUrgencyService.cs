namespace ticketing_system.Models.Ticket.Services.Abstraction
{
    public interface IUrgencyService
    {
        Task<Urgency> GetUrgencyByIdAsync(int id);
        Task<List<Urgency>> GetAllUrgencyAsync();
        Task CreateUrgency(Urgency urgency);
    }
}
