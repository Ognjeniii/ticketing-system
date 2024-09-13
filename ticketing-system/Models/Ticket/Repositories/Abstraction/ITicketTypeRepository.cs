namespace ticketing_system.Models.Ticket.Repositories.Abstraction
{
    public interface ITicketTypeRepository
    {
        Task<TicketType> CreateAsync(TicketType ticket);
        Task<TicketType> GetByIdAsync(int id);
        List<Task<TicketType>> GetAllAsync();

    }
}
