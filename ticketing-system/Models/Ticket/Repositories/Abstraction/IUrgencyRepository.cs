namespace ticketing_system.Models.Ticket.Repository.Abstraction
{
    public interface IUrgencyRepository
    {
        Task Create(Urgency urgency);
        Task<Urgency> GetById(int id);
        Task<List<Urgency>> GetAll();
    }
}
