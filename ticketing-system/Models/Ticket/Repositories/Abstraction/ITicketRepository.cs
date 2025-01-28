using Microsoft.AspNetCore.Mvc;
using ticketing_system.ViewModels.Tickets;

namespace ticketing_system.Models.Ticket.Repository.Abstraction
{
    public interface ITicketRepository
    {
        Task Create(Ticket ticket);
        Task<Ticket> GetById(int id);
        Task<List<Ticket>> GetByCreator(int userId);
        Task<List<Ticket>> GetByGroupId(int groupId);
        Task<List<Ticket>> FilterByStatusAndGroupId(int status, int groupId);
        Task<List<Ticket>> GetTicketsByExecutor(int userId);
        Task<List<ListTicketsViewModel>> GetListTicketsViewModel(int groupId);

    }
}
