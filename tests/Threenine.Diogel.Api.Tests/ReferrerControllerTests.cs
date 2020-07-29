using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using Moq;
using Threenine.Diogel.Api.Controllers;
using Threenine.Diogel.Domain.Bots;
using Threenine.Diogel.Service;
using Xunit;

namespace Threenine.Diogel.Api.Tests
{
    public class ReferrerControllerTests
    {
        private readonly Mock<IReferrerService> _referrerService;

        public ReferrerControllerTests()
        {
            _referrerService = new Mock<IReferrerService>(MockBehavior.Strict);
        }

        [Fact]
        public void Get_Should_Return_List_Of_Referrers()
        {
            var referrerList = Builder<Referrer>.CreateListOfSize(20).Build();
            _referrerService.Setup(service => service.GetAllActive()).Returns(referrerList.AsEnumerable);

            var controller = new ReferrerController(_referrerService.Object);
            var values = controller.Get();

            Assert.Equal(20, values.Count());
            Assert.IsAssignableFrom<IEnumerable<Referrer>>(values);

        }

       }
}
