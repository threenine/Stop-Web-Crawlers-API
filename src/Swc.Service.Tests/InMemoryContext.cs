using System;
using System.Collections.Generic;
using System.Text;
using Api.Database;
using Api.Database.Entity.Threats;
using Microsoft.EntityFrameworkCore;

namespace Swc.Service.Tests
{
    public class TestDBContext : ApiContext
    {
        public TestDBContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Threat>().Property(p => p.Identifier).HasComputedColumnSql("CONCAT('" + DBGlobals.IdentifierFormat + "' , [Id])");
            modelBuilder.Entity<ThreatType>();
            modelBuilder.Entity<Status>();
            base.OnModelCreating(modelBuilder);
        }
    }
   
}
