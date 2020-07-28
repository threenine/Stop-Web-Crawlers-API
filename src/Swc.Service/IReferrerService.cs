using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Bots;

namespace Swc.Service
{
    public interface IReferrerService
    {
        IEnumerable<Referrer> GetAllActive();
        Task<Referrer> Insert(AddRefererer referrer);
        Task<Referrer> Details(string name);

    }
}