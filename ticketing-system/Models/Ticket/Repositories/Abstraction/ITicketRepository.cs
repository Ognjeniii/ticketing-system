using Microsoft.AspNetCore.Mvc;

namespace ticketing_system.Models.Ticket.Repository.Abstraction
{
    public interface ITicketRepository
    {
        Task Create(Ticket ticket);
        Task<Ticket> GetById(int id);
        Task<List<Ticket>> GetByCreator(int userId);
        Task<List<Ticket>> GetByGroupId(int groupId);
        Task<List<Ticket>> FilterByStatusAndGroup(int status, int groupId);

    }
}
