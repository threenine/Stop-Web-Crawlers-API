using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
          return Mapper.Map<IEnumerable<Referrer>>(source: threats.Items);
          
        }

        public async Task<Referrer>  Insert(AddRefererer referrer)
        {
            // TODO : Move this to a cache lookup.  We don't want to query on every ADD.
            // TODO :  Expected Volumes could be immense to so we need to optimise 
            var refType =_unitOfWork.GetRepository<ThreatType>().SingleOrDefault(x => x.Name == Referer);
            var status = _unitOfWork.GetRepository<Status>().SingleOrDefault(x=> x.Name == Moderate);

            var threat = Mapper.Map<Threat>(referrer);
           
            threat.ThreatType = refType;
            threat.Status = status;
           
           var result = await  _unitOfWork.GetRepositoryAsync<Threat>().InsertAsync(threat);
          await  _unitOfWork.CommitAsync();
                
            return Mapper.Map<Referrer>(result);

        }

        public async Task<Referrer> Details(string name)
        {
            var threat = _unitOfWork.GetRepository<Threat>().SingleOrDefault(x => x.Referer == name);
            return Mapper.Map<Referrer>(threat);
        }
    }
}
