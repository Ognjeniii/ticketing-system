namespace ticketing_system.Models.Ticket.Services.Abstraction
{
    public interface ITicketService
    {
        Task CreateAsync(Ticket ticket);
        Task<Ticket> GetByIdAsync(int id);
        Task<List<Ticket>> GetByCreatorAsync(int userId);
        Task<List<Ticket>> GetByGroupIdAsync(int groupId);
        Task<List<Ticket>> FilterByStatusAndGroupAsync(int status, int groupId);
    }
}
