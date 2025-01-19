namespace ticketing_system.Models.Ticket.Repositories.Abstraction
{
    public interface ITicketTypeRepository
    {
        Task CreateAsync(TicketType ticketType);
        Task<TicketType> GetByIdAsync(int id);
        Task<List<TicketType>> GetAllAsync();

    }
}
