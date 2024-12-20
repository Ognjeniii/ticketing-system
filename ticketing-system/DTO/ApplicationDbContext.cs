using Microsoft.EntityFrameworkCore;
using ticketing_system.Models.Ticket;
using ticketing_system.Models.User;

namespace ticketing_system.DTO
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Ticket>()
                .HasKey(u => u.TicketId);
        }

    }
}
