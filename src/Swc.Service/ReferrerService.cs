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
        public IEnumerable<Referer> GetAllActive()
        {
            var threats = _unitOfWork.GetRepository<Threat>().Get(predicate: x => x.Status.Name == Enabled && x.ThreatType.Name == Referer)
                .Join(inner: _unitOfWork.GetRepository<Status>().Get(), outerKeySelector: t => t.StatusId, innerKeySelector: s => s.Id, resultSelector: (t, s) => new {t, s})
                .Join(inner: _unitOfWork.GetRepository<ThreatType>().Get(), outerKeySelector: tt => tt.t.TypeId, innerKeySelector: type => type.Id,
                    resultSelector: (t1, type) =>
                        new Threat { Referer = @t1.t.Referer, ThreatType = type, Status = @t1.s});

            return Mapper.Map<IEnumerable<Referer>>(source: threats);
          
        }

        public string  Insert(Referer referer)
        {
            var refType =_unitOfWork.GetRepository<ThreatType>().Get(x => x.Name == Referer).SingleOrDefault();
            var status = _unitOfWork.GetRepository<Status>().Get(x=> x.Name == Moderate).SingleOrDefault();

            var threat = Mapper.Map<Threat>(referer);

            threat.StatusId =  status.Id;
            threat.TypeId = refType.Id;
            threat.ThreatType = refType;
            threat.Status = status;
            //var repo = _unitOfWork.
            _unitOfWork.GetRepository<Threat>().Add(threat);
            _unitOfWork.SaveChanges();

            return threat.Identifier;

        }

        public Referer GetReferer(string identifier)
        {
            var threat = _unitOfWork.GetRepository<Threat>().Get(x => x.Identifier == identifier).SingleOrDefault();

            return Mapper.Map<Referer>(threat);
        }
    }
}
