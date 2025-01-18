using ticketing_system.DTO;
using ticketing_system.Models.Ticket.Repository.Abstraction;
using ticketing_system.Models.Ticket.Repository.Implementation;
using ticketing_system.Models.Ticket.Services.Abstraction;

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

        public Task<Ticket> GetByIdAsync(int id)
        {
            return _ticketRepository.GetById(id);
        }

        public Task<List<Ticket>> GetByCreatorAsync(int userId)
        {
            return _ticketRepository.GetByCreator(userId);
        }

        public Task<List<Ticket>> GetByGroupIdAsync(int groupId)
        {
            return _ticketRepository.GetByGroupId(groupId);
        }

        // Možda ne bi trebalo da se isto zovu repository metoda i service metoda
        public Task<List<Ticket>> FilterByStatusAndGroupIdAsync(int status, int groupId)
        {
            return _ticketRepository.FilterByStatusAndGroupId(status, groupId);
        }

        // Možda ne bi trebalo da se isto zovu repository metoda i service metoda
        public Task<List<Ticket>> GetAssignedTicketsByGroupId(int groupId)
        {
            return _ticketRepository.GetAssignedTicketsByGroupId(groupId);
        }
    }
}
