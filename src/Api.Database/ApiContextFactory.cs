using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace Api.Database
{
public class ApiContextFactory : IDbContextFactory<ApiContext>
    {
        public ApiContext Create(DbContextFactoryOptions options)
        {
           var builder = new DbContextOptionsBuilder<ApiContext>();
            builder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=config;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new ApiContext(builder.Options);
        }
    }
}