using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Threenine;

public class DiogelContext : BaseContext<DiogelContext>
{
    public DiogelContext(DbContextOptions<DiogelContext> options)
        : base(options)
    {
    }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Diogel");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}