using System;
using System.Collections.Generic;
using System.Linq;
using Api.Database.Entity.Threats;
using Api.Domain.Bots;
using Threenine.Data;
using AutoMapper;

namespace Swc.Service
{
    public class ReferrerService : IReferrerService
    {
        private readonly IRepository<Threat> _refererRepository;

        public ReferrerService(IRepository<Threat> repository)
        {
            _refererRepository = repository;
        }
        public IEnumerable<Referer> GetAll()
        {
            var threats = _refererRepository.Get();
            if (threats != null)
            {
                return Mapper.Map<IEnumerable<Referer>>(threats);
            }

            return null;
        }
    }
}
