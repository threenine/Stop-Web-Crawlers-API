using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public void Get_Should_Return_List_Of_Referrers()
        {
            var referrerList = Builder<Referrer>.CreateListOfSize(20).Build().AsEnumerable();
            var referrerServiceMock = new Mock<IReferrerService>();
            referrerServiceMock.Setup(service => service.GetAllActive())
                .Returns(referrerList);

            var controller = new ReferrerController(referrerServiceMock.Object);
            var values = controller.Get();

            Assert.Equal(20, values.Count());
            Assert.IsAssignableFrom<IEnumerable<Referrer>>(values);

        }

        [Fact]
        public void Get_Should_Return_Null()
        {
           var referrerServiceMock = new Mock<IReferrerService>();
            referrerServiceMock.Setup(service => service.GetAllActive());

            var controller = new ReferrerController(referrerServiceMock.Object);
            var values = controller.Get();

            Assert.Null(values);
         }


    }
}
