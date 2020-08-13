using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Threenine.Diogel.Database.Entity.Threats;
using Threenine.Diogel.Database.Postgre.Configuration;
using Threenine.Diogel.Database.Postgre.Constants;

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
            modelBuilder.HasPostgresExtension(PostgresExtensions.UUIDGenerator);
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new TypeConfiguration());
            modelBuilder.ApplyConfiguration(new ThreatConfiguration());
            modelBuilder.ApplyConfiguration(new ClassificationConfiguration());
        }
    }
}
