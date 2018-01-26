using System.Collections.Generic;
using Api.Domain.Bots;

namespace Swc.Service
{
    public interface IReferrerService
    {
        IEnumerable<Referer> GetAllActive();

    }
}