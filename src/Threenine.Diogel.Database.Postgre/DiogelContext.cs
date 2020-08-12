using Microsoft.EntityFrameworkCore;
using Threenine.Diogel.Database.Entity.Threats;
using Threenine.Diogel.Database.Postgre.Configuration;

namespace Threenine.Diogel.Database.Postgre
{
    public class DiogelContext : DbContext
    {
        public DiogelContext(DbContextOptions<DiogelContext> options) : base(options)
        {
        }
        public DbSet<Threat> Threats { get; set; }
        public DbSet<Type> Type { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new TypeConfiguration());
            modelBuilder.ApplyConfiguration(new ThreatConfiguration());
            modelBuilder.ApplyConfiguration(new ClassificationConfiguration());
        }
    }
}
