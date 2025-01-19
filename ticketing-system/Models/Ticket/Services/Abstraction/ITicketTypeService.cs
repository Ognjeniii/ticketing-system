namespace ticketing_system.Models.Ticket.Services.Abstraction
{
    public interface ITicketTypeService
    {
        Task<TicketType> GetByIdAsync(int id);
        Task CreateAsync(TicketType ticketType);
        Task<List<TicketType>> GetAllAsync();
    }
}
