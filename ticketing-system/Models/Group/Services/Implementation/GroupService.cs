using ticketing_system.Models.Group.Repositories.Abstraction;
using ticketing_system.Models.Group.Services.Abstraction;

namespace ticketing_system.Models.Group.Services.Implementation
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public Task CreateAsync(Group group)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Group>> GetAllAsync()
        {
            return await _groupRepository.GetAll();
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
