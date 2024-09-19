using ticketing_system.Models.Group.Repositories.Abstraction;

namespace ticketing_system.Models.Group.Repositories.Implementation
{
    public class GroupRepository : IGroupRepository
    {
        public Task Create(Group group)
        {
            throw new NotImplementedException();
        }

        public Task<List<Group>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Group> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Group> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
