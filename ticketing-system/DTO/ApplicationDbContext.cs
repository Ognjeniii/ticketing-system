using Microsoft.EntityFrameworkCore;
using ticketing_system.Models.Group;
using ticketing_system.Models.Ticket;
using ticketing_system.Models.User;

namespace ticketing_system.DTO
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Urgency> Urgencies { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Ticket>()
                .HasKey(u => u.TicketId);

            modelBuilder.Entity<Urgency>()
                .HasKey(u => u.UrgencyId);

            modelBuilder.Entity<TicketType>()
                .HasKey(u => u.TicketTypeId);

            modelBuilder.Entity<Group>()
                .HasKey(u => u.GroupId);

            modelBuilder.Entity<Status>()
                .HasKey(u => u.StatusId);
        }

    }
}
