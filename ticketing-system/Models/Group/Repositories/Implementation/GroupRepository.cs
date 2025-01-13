using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using ticketing_system.DTO;
using ticketing_system.Models.Group.Repositories.Abstraction;

namespace ticketing_system.Models.Group.Repositories.Implementation
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _context;
        public GroupRepository(ApplicationDbContext context) 
        {
            _context = context; 
        }

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
