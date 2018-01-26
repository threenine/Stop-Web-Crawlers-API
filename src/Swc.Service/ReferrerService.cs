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
        private readonly IRepository<Status> _statusRepository;
        private readonly IRepository<ThreatType> _typeRepository;

        public ReferrerService(IRepository<Threat> repository, IRepository<Status> statusRepository, IRepository<ThreatType> typeRepository)
        {
            _refererRepository = repository;
            _statusRepository = statusRepository;
            _typeRepository = typeRepository;
        }
        public IEnumerable<Referer> GetAll()
        {

            var threats = _refererRepository.Get()
                .Join(_statusRepository.Get(), t => t.StatusId, s => s.Id, (t, s) => new {t, s})
                .Join(_typeRepository.Get(), tt => tt.t.TypeId, type => type.Id,
                    (t1, type) =>
                        new Threat {Name = @t1.t.Name, Referer = @t1.t.Referer, Type = type, Status = @t1.s});
               
                
            if (threats != null)
             {
                return Mapper.Map<IEnumerable<Referer>>(threats);
            }

            return default(IEnumerable<Referer>);
        }
    }
}
