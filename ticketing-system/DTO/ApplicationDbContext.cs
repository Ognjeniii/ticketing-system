using Microsoft.EntityFrameworkCore;
using ticketing_system.Models.Ticket;

namespace ticketing_system.DTO
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Urgency> Urgency { get; set; }
    }
}
