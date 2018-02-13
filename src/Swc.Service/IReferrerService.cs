using System.Collections.Generic;
using Api.Domain.Bots;

namespace Swc.Service
{
    public interface IReferrerService
    {
        IEnumerable<Referrer> GetAllActive();
        string Insert(Referrer referrer);
        Referrer GetReferer(string identifier);

    }
}