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

        // Method that returns list of tickets for group id, but in ListTicketsViewModel type,
        // where status_id (finished) is not 2
        Task<List<ListTicketsViewModel>> GetVMByGroupAsync(int groupId);

        // Method that retrieves list of ListTicketViewModel objects for given status id and group id 
        Task<List<ListTicketsViewModel>> GetVMByStatusAndGroupAsync(int status, int groupId);

        // Method that retrieves list of ListTicketViewModel objects for given user id (for column executor),
        // where status_id (finished) is not 2
        Task<List<ListTicketsViewModel>> GetVMByExecutorAsync(int userId);

        // The method we use to search for tickets
        Task<List<ListTicketsViewModel>> SearchTicketsAsync(SearchTicketViewModelComposite model);
    }
}
