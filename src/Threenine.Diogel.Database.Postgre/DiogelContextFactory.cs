using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Threenine.Diogel.Database.Postgre
{
    public class DiogelContextFactory : IDesignTimeDbContextFactory<DiogelContext>
    {
        public DiogelContextFactory()
        {
        }

        private IConfiguration Configuration =>  new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        public DiogelContext CreateDbContext(string[] args)
        {
            
            var builder = new DbContextOptionsBuilder<DiogelContext>();
            builder.UseNpgsql(Configuration.GetConnectionString("postgre"));

            return new DiogelContext(builder.Options);
        }
    }
}