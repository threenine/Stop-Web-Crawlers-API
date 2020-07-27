using System;
using System.Collections.Generic;
using System.Linq;
using Api.Database.Entity.Threats;
using Api.Domain.Bots;
using Threenine.Data;
using AutoMapper;

namespace Swc.Service
{
    public class ReferrerService : IReferrerService
    {
      
        private readonly IUnitOfWork _unitOfWork;
        private const string Enabled = "Enabled";
        private const string Referer = "Referer";
        private const string Moderate = "Moderate";

        public ReferrerService(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }
        public IEnumerable<Referrer> GetAllActive()
        {
            var threats = _unitOfWork.GetRepository<Threat>()
                .GetList(predicate: x => x.Status.Name == Enabled && x.ThreatType.Name == Referer );
          return Mapper.Map<IEnumerable<Referrer>>(source: threats);
          
        }

        public string  Insert(AddRefererer referrer)
        {
            // TODO : Move this to a cache lookup.  We don't want to query on every ADD.
            // TODO :  Expected Volumes could be immense to so we need to optimise 
            var refType =_unitOfWork.GetRepository<ThreatType>().SingleOrDefault(x => x.Name == Referer);
            var status = _unitOfWork.GetRepository<Status>().SingleOrDefault(x=> x.Name == Moderate);

            var threat = Mapper.Map<Threat>(referrer);
           
            threat.ThreatType = refType;
            threat.Status = status;
           
            _unitOfWork.GetRepository<Threat>().Insert(threat);
            _unitOfWork.Commit();

            return threat.Identifier;

        }

        public Referrer GetReferer(string identifier)
        {
            var threat = _unitOfWork.GetRepository<Threat>().SingleOrDefault(x => x.Identifier == identifier);
            return Mapper.Map<Referrer>(threat);
        }
    }
}
