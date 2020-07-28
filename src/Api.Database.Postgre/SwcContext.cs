using Api.Database.Entity.Threats;
using Api.Database.Postgre.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Api.Database.Postgre
{
    public class SwcContext : DbContext
    {
        public SwcContext(DbContextOptions<SwcContext> options) : base(options)
        {
        }
        public DbSet<Threat> Threats { get; set; }
        public DbSet<ThreatType> Type { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new ThreatTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ThreatConfiguration());
        }
    }
}
