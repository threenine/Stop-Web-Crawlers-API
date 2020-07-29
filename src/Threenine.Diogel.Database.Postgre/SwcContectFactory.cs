using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Threenine.Diogel.Database.Postgre
{
    public class SwcContextFactory : IDesignTimeDbContextFactory<SwcContext>
    {
        public SwcContextFactory()
        {
        }

        private IConfiguration Configuration =>  new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        public SwcContext CreateDbContext(string[] args)
        {
            
            var builder = new DbContextOptionsBuilder<SwcContext>();
            builder.UseNpgsql(Configuration.GetConnectionString("postgre"));

            return new SwcContext(builder.Options);
        }
    }
}