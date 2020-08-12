using System.Collections.Generic;
using System.Threading.Tasks;
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
            return null;
        }

        public async Task<Referrer>  Insert(AddRefererer referrer)
        {
            return null;
        }

        public async Task<Referrer> Details(string name)
        {
            return null;
        }
    }
}
