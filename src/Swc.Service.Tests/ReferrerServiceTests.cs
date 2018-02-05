using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Api.Database.Entity.Threats;
using Api.Domain.Bots;
using FizzWare.NBuilder;
using Moq;
using Threenine.Data;
using Threenine.Map;
using Xunit;

namespace Swc.Service.Tests
{
    public class ReferrerServiceTests :  IClassFixture<ServiceTestFixture>, IDisposable
    {
        private readonly ServiceTestFixture _serviceFixture;
        public ReferrerServiceTests(ServiceTestFixture fixture)
        {
            _serviceFixture = fixture;
         
        }

        [Fact]
        public void Should_Return_Referrer_Enumerable()
        {
            var threatRepositoryMock = new Mock<IRepository<Threat>>();
            var typeRepositoryMock = new Mock<IRepository<ThreatType>>();
            var statusRepositoryMock = new Mock<IRepository<Status>>();

            threatRepositoryMock.Setup(x => x.Get(It.IsAny<Expression<Func<Threat,bool>>>())).Returns(_serviceFixture.ThreatList);
            typeRepositoryMock.Setup(x => x.Get()).Returns(_serviceFixture.ThreatTypes);
            statusRepositoryMock.Setup(x => x.Get()).Returns(_serviceFixture.Statuses);

            var service = new ReferrerService(threatRepositoryMock.Object, statusRepositoryMock.Object,
                typeRepositoryMock.Object);

            var referers = service.GetAllActive();

            Assert.Equal(10, referers.Count());
            Assert.IsAssignableFrom<IEnumerable<Referer>>(referers);

        }

        public void Dispose()
        {
            _serviceFixture?.Dispose();
        }
    }
}
