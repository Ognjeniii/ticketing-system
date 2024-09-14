using Microsoft.AspNetCore.Mvc;

namespace ticketing_system.Models.Ticket.Repository.Abstraction
{
    public interface ITicketRepository
    {
        Task Create(Ticket ticket);
        Task<Ticket> GetById(int id);
    }
}
