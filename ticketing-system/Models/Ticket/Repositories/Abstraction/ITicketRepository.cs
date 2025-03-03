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
        Task<List<ListTicketsViewModel>> GetVMByGroup(int groupId);
        Task<List<ListTicketsViewModel>> GetVMByStatusAndGroup(int statusId, int groupId);
        Task<List<ListTicketsViewModel>> GetVMByExecutor(int userId);
        Task<List<ListTicketsViewModel>> GetVMByCreator(int userId);
        Task<List<ListTicketsViewModel>> SearchTicket(SearchTicketViewModelComposite ticket);

    }
}
