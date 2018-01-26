using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Api.Database.Entity.Threats;
using Api.Domain.Bots;
using FizzWare.NBuilder;
using Moq;
using PhilosophicalMonkey;
using Threenine.Data;
using Threenine.Map;
using Xunit;

namespace Swc.Service.Tests
{
    public class ReferrerServiceTests
    {
        public ReferrerServiceTests()
        {
            var seedTypes = new Type[] { typeof(Api.Domain.Marker) };
            var assemblies = Reflect.OnTypes.GetAssemblies(seedTypes);
            var typesInAssemblies = Reflect.OnTypes.GetAllExportedTypes(assemblies);
            MapConfigurationFactory.LoadAllMappings(typesInAssemblies);
        }

        [Fact]
        public void Should_Return_Referrer_Enumerable()
        {
            var threatRepositoryMock = new Mock<IRepository<Threat>>();
            var typeRepositoryMock = new Mock<IRepository<ThreatType>>();
            var statusRepositoryMock = new Mock<IRepository<Status>>();

            var threats = Builder<Threat>.CreateListOfSize(10).All().With(t => t.TypeId = 1)
                .With(t => t.StatusId = 1).Build().AsEnumerable();
            var types = Builder<ThreatType>.CreateListOfSize(3).TheFirst(1).With(x => x.Id = 1).Build().AsEnumerable();
            var status = Builder<Status>.CreateListOfSize(4).TheFirst(1).With(x => x.Id = 1).Build().AsEnumerable();

            threatRepositoryMock.Setup(x => x.Get(It.IsAny<Expression<Func<Threat,bool>>>())).Returns(threats);
            typeRepositoryMock.Setup(x => x.Get()).Returns(types);
            statusRepositoryMock.Setup(x => x.Get()).Returns(status);

            var service = new ReferrerService(threatRepositoryMock.Object, statusRepositoryMock.Object,
                typeRepositoryMock.Object);

            var referers = service.GetAllActive();

            Assert.Equal(10, referers.Count());
            Assert.IsAssignableFrom<IEnumerable<Referer>>(referers);

        }
    }
}
