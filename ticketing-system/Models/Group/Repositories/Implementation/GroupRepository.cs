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

        public async Task<List<Group>> GetAll()
        {
            return await _context.Groups.ToListAsync();
        }

        public Task<Group> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Group> GetByName(string name)
        {
            throw new NotImplementedException();
        }

    }
}
