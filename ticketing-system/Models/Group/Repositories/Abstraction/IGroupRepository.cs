namespace ticketing_system.Models.Group.Repositories.Abstraction
{
    public interface IGroupRepository
    {
        Task Create(Group group);
        Task<Group> GetByIdAsync(int id);
        Task<Group> GetByNameAsync(string name);
        Task<List<Group>> GetAllAsync();
    }
}
