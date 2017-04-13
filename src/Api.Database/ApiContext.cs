using System;
using Microsoft.EntityFrameworkCore;
using Api.Database.Entity.Threats;
using Api.Database.Entity;
using Portal.Core;
using System.Threading.Tasks;
using System.Linq;

namespace Api.Database
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
        public DbSet<Threat> Threats { get; set; }
        public DbSet<ThreatType> Type { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.HasDefaultSchema(schema: SchemaName.Portal);
            modelBuilder.Entity<Threat>();
            modelBuilder.Entity<ThreatType>();
            modelBuilder.Entity<Status>();
            base.OnModelCreating(modelBuilder);


        }

        public override int SaveChanges()
        {
            AddAuitInfo();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddAuitInfo();
            return await base.SaveChangesAsync();
        }

        private void AddAuitInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;
                }
            ((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }
    }
}

