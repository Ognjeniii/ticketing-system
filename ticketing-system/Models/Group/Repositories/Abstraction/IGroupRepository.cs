namespace ticketing_system.Models.Group.Repositories.Abstraction
{
    public interface IGroupRepository
    {
        Task Create(Group group);
        Task<Group> GetById(int id);
        Task<Group> GetByName(string name);
        Task<List<Group>> GetAll();
    }
}
