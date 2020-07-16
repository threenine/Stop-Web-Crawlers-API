using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;


namespace Api.Database
{
public class ApiContextFactory : IDesignTimeDbContextFactory<ApiContext>
    {
        public ApiContextFactory()
        {
        }

        private IConfiguration Configuration =>  new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        public ApiContext CreateDbContext(string[] args)
        {
            
            var builder = new DbContextOptionsBuilder<ApiContext>();
            builder.UseNpgsql(Configuration.GetConnectionString("defaultConnection"));

            return new ApiContext(builder.Options);
        }
    }
}