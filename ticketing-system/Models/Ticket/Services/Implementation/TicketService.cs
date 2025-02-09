using ticketing_system.DTO;
using ticketing_system.Models.Ticket.Repository.Abstraction;
using ticketing_system.Models.Ticket.Repository.Implementation;
using ticketing_system.Models.Ticket.Services.Abstraction;
using ticketing_system.ViewModels.Tickets;

namespace ticketing_system.Models.Ticket.Services.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public async Task CreateAsync(Ticket ticket)
        {
            await _ticketRepository.Create(ticket);
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            return await _ticketRepository.GetById(id);
        }

        public async Task<List<Ticket>> GetByCreatorAsync(int userId)
        {
            return await _ticketRepository.GetByCreator(userId);
        }

        public async Task<List<Ticket>> GetByGroupIdAsync(int groupId)
        {
            return await _ticketRepository.GetByGroupId(groupId);
        }

        public async Task<List<ListTicketsViewModel>> GetVMByGroupAsync(int groupId)
        {
            return await _ticketRepository.GetVMByGroup(groupId);
        }

        public async Task<List<ListTicketsViewModel>> GetVMByStatusAndGroupAsync(int status, int groupId)
        {
            return await _ticketRepository.GetVMByStatusAndGroup(status, groupId);
        }

        public async Task<List<ListTicketsViewModel>> GetVMByExecutorAsync(int userId)
        {
            return await _ticketRepository.GetVMByExecutor(userId);
        }

        public async Task<List<ListTicketsViewModel>> SearchTicketsAsync(SearchTicketViewModelComposite model)
        {
            return await _ticketRepository.SearchTicket(model);
        }
    }
}
