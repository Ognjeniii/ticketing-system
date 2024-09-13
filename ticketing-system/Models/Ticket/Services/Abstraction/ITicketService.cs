namespace ticketing_system.Models.Ticket.Services.Abstraction
{
    public interface ITicketService
    {
        Task CreateTicketAsync(Ticket ticket);
        Task<Ticket> GetTicketById(int id);

    }
}
