using System;
using System.Collections.Generic;
using Api.Domain.Bots;

namespace Swc.Service
{
    public interface IReferrerService
    {
        IEnumerable<Referrer> GetAllActive();
        Guid Insert(AddRefererer referrer);
        Referrer Details(string name);

    }
}