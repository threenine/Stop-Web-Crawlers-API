using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Database.Entity.Threats;
using Threenine.Map;
using FizzWare.NBuilder;

namespace Swc.Service.Tests
{
   public class ServiceTestFixture : IDisposable
    {

        public ServiceTestFixture()
        {
            MapConfigurationFactory.Scan<ServiceTestFixture>();
        }

        public IEnumerable<Threat> ThreatList
        {
            get
            {
                return Builder<Threat>.CreateListOfSize(10).All().With(t => t.TypeId = 1)
                    .With(t => t.StatusId = 1).Build().AsEnumerable();
            }
        }

        public IEnumerable<ThreatType> ThreatTypes
        {
            get
            {
                return Builder<ThreatType>.CreateListOfSize(3).TheFirst(1).With(x => x.Id = 1).Build().AsEnumerable();
            }
        }

        public IEnumerable<Status> Statuses
        {
            get
            {
                return Builder<Status>.CreateListOfSize(4).TheFirst(1).With(x => x.Id = 1).Build().AsEnumerable();
            }
        }
        public void Dispose()
        {
        }
    }
}
