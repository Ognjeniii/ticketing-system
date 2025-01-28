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

        public async Task<List<Ticket>> FilterByStatusAndGroupIdAsync(int status, int groupId)
        {
            return await _ticketRepository.FilterByStatusAndGroupId(status, groupId);
        }

        public async Task<List<Ticket>> GetTicketsByExecutorAsync(int userId)
        {
            return await _ticketRepository.GetTicketsByExecutor(userId);
        }

        public async Task<List<ListTicketsViewModel>> GetListTicketsViewModelAsync(int groupId)
        {
            return await _ticketRepository.GetListTicketsViewModel(groupId);
        }
    }
}
