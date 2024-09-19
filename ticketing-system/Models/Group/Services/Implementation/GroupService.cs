using ticketing_system.Models.Group.Services.Abstraction;

namespace ticketing_system.Models.Group.Services.Implementation
{
    public class GroupService : IGroupService
    {
        public Task Create(Group group)
        {
            throw new NotImplementedException();
        }

        public Task<List<Group>> GetAll()
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
