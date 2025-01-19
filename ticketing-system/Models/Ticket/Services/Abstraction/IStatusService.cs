namespace ticketing_system.Models.Ticket.Services.Abstraction
{
    public interface IStatusService
    {
        Task CreateAsync(Status status);
        Task<Status> GetByIdAsync(int id);
        Task<List<Status>> GetAllAsync();
    }
}
