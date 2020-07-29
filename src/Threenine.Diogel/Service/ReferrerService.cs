using System.Collections.Generic;
using System.Threading.Tasks;
using Threenine.Diogel.Domain.Bots;

namespace Threenine.Diogel.Service
{
    public interface IReferrerService
    {
        IEnumerable<Referrer> GetAllActive();
        Task<Referrer> Insert(AddRefererer referrer);
        Task<Referrer> Details(string name);

    }
}