namespace ticketing_system.Models.Ticket.Services.Abstraction
{
    public interface IStatusService
    {
        Task Create(Status status);
        Task<Status> GetByIdAsync(int id);
        Task<List<Status>> GetAll();
    }
}
