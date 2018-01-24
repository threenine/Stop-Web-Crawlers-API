using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Bots;
using FizzWare.NBuilder;
using Moq;
using Newtonsoft.Json.Linq;
using swcApi.Controllers;
using Swc.Service;
using Threenine.Data;
using Xunit;

namespace swcApi.Tests
{
    public class ReferrerControllerTests
    {
        [Fact]
        public void ShouldReturnListOfReferrers()
        {
            var referrerList = Builder<Referer>.CreateListOfSize(20).Build().AsEnumerable();
            var referrerServiceMock = new Mock<IReferrerService>();
            referrerServiceMock.Setup(service => service.GetAll())
                .Returns(referrerList);

            var controller = new ReferrerController(referrerServiceMock.Object);
            var values = controller.Get();

            Assert.Equal(20, values.Count());
            Assert.IsAssignableFrom<IEnumerable<Referer>>(values);

        }
    }
}
