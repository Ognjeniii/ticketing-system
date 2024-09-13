namespace ticketing_system.Models.Ticket.Repository.Abstraction
{
    public interface ITicketRepostiroy
    {
        Task<Ticket> Create(Ticket ticket);
        Task<Ticket> GetById(int id);
    }
}
