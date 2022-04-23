using Microsoft.EntityFrameworkCore;
using Tickets.Data.Entities;

namespace Tickets.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Entrance> Entrances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ticket>().HasIndex(t => t.Name).IsUnique();
            modelBuilder.Entity<Ticket>().HasIndex("Id", "EntranceId").IsUnique();
        }
    }
}
