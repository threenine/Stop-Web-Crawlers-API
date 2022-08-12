using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Threenine;

internal class DiogelContextFactory : IDesignTimeDbContextFactory<DiogelContext>
{
    public DiogelContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<DiogelContext> dbContextOptionsBuilder =
            new();

        dbContextOptionsBuilder.UseNpgsql(@"localBuild");
        return new DiogelContext(dbContextOptionsBuilder.Options);
    }
}
