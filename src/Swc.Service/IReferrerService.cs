using System.Collections.Generic;
using Api.Domain.Bots;

namespace Swc.Service
{
    public interface IReferrerService
    {
        IEnumerable<Referrer> GetAllActive();
        string Insert(AddRefererer referrer);
        Referrer GetReferer(string identifier);

    }
}