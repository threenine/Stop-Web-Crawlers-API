using System.Collections.Generic;
using Api.Domain.Bots;

namespace Swc.Service
{
    public interface IReferrerService
    {
        IEnumerable<Referer> GetAllActive();
        string Insert(Referer referer);
        Referer GetReferer(string identifier);

    }
}