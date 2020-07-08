using System;
using Api.Database.Entity.Threats;
using FizzWare.NBuilder;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Api.Database.Tests
{
    public class DatabaseCreateTests
    {
        [Fact]
        public void ShouldInsertNewThreat()
        {
            var threat = Builder<Threat>.CreateNew().With(x => x.ThreatType = Builder<ThreatType>.CreateNew().Build())
                .With(x => x.Status = Builder<Status>.CreateNew().Build()).Build();

            var context = GetInMemoryContext();
            context.Threats.Add(threat);
            context.SaveChanges();
            Assert.Equal(2, threat.Id);

        }

        private ApiContext GetInMemoryContext()
        {

            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseSqlite("DataSource=:memory:")
                .EnableSensitiveDataLogging()
                .Options;


            var context = new ApiContext(options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();


            var status = Builder<Status>.CreateNew().Build();
            var threatType = Builder<ThreatType>.CreateNew().Build();

            var threat = Builder<Threat>.CreateNew().With(x => x.ThreatType = Builder<ThreatType>.CreateNew().Build())
                .With(x => x.Status = Builder<Status>.CreateNew().Build()).Build();

            context.Status.Add(status);
            context.Type.Add(threatType);
            context.Threats.Add(threat);
            context.SaveChanges();
            return context;
        }
    }
}
