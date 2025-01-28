using ticketing_system.ViewModels.Tickets;

namespace ticketing_system.Models.Ticket.Services.Abstraction
{
    public interface ITicketService
    {
        // Method for creating ticket
        Task CreateAsync(Ticket ticket);

        // Method used for getting ticket by ticketId
        Task<Ticket> GetByIdAsync(int id);

        // Method used for getting tickets by creator
        Task<List<Ticket>> GetByCreatorAsync(int userId);

        // Method used for getting tickets by groupId
        Task<List<Ticket>> GetByGroupIdAsync(int groupId);

        // Method used for getting list of tickets by statusId and grouId
        Task<List<Ticket>> FilterByStatusAndGroupIdAsync(int status, int groupId);

        // Method used for getting tickets by executor
        Task<List<Ticket>> GetTicketsByExecutorAsync(int userId);

        // Method that returns list of tickets, but in ListTicketsViewModel type
        Task<List<ListTicketsViewModel>> GetListTicketsViewModelAsync(int groupId);
    }
}
