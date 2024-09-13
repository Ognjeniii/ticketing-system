namespace ticketing_system.Models.Ticket.Services.Abstraction
{
    public interface ITicketTypeService
    {
        Task<TicketType> GetByIdAsync(int id);
        Task Create(TicketType ticketType);
        Task<List<TicketType>> GetAll();
    }
}
