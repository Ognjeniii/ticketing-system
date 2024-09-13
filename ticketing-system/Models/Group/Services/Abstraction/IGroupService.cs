namespace ticketing_system.Models.Group.Services.Abstraction
{
    public interface IGroupService
    {
        Task Create(Group group);
        Task<Group> GetByIdAsync(int id);   
        Task<Group> GetByNameAsync(string name);
        Task<List<Group>> GetAll(); 
    }
}
