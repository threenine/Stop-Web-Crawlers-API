using System;
using System.Collections.Generic;
using System.Text;
using Api.Database;
using Api.Database.Entity.Threats;
using Microsoft.EntityFrameworkCore;

namespace Swc.Service.Tests
{
    public class InMemoryTestFixture : IDisposable
    {
        public ApiContext Context => InMemoryContext();

        public void Dispose()
        {
            Context?.Dispose();
        }

        private ApiContext InMemoryContext()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;
            var context = new ApiContext(options);

            context.Threats.AddRange();
            return context;
        }
    }
}
