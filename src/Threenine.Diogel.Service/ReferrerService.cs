using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Threenine.Data;
using Threenine.Diogel.Database.Entity.Threats;
using Threenine.Diogel.Domain.Bots;

namespace Threenine.Diogel.Service
{
    public class ReferrerService : IReferrerService
    {
        private readonly IUnitOfWork _unitOfWork;
      
        public ReferrerService(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }
        public IEnumerable<Referrer> GetAllActive()
        {
            var threats = _unitOfWork.GetRepository<Threat>().GetList();
          return Mapper.Map<IEnumerable<Referrer>>(source: threats.Items);
          
        }

        public async Task<Referrer>  Insert(AddRefererer referrer)
        {
           var threat = Mapper.Map<Threat>(referrer);
           
           var result = await  _unitOfWork.GetRepositoryAsync<Threat>().InsertAsync(threat);
           await  _unitOfWork.CommitAsync();
                
            return Mapper.Map<Referrer>(result);

        }

        public async Task<Referrer> Details(string name)
        {
            var threat = await _unitOfWork.GetRepositoryAsync<Threat>().SingleOrDefaultAsync(x => x.Referer == name);
            return Mapper.Map<Referrer>(threat);
        }
    }
}
