using System;
using System.Runtime.CompilerServices;
using Api.Database.Entity.Threats;
using AutoMapper;
using Threenine.Map;


namespace Api.Domain.Bots
{
 public class Referer   : ICustomMap
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        
        public void CustomMap(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Threat, Referer>()
                 .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Referer))
                 .ForMember(dest => dest.Status, opt => opt.ResolveUsing<StatusResolver>())
                 .ForMember(dest => dest.Type, opt => opt.ResolveUsing<ThreatTypeResolver>())
                .ReverseMap();
        }

     }

   public class StatusResolver : IValueResolver<Threat, Referer , string>
    {
        public string Resolve(Threat source, Referer destination, string destMember, ResolutionContext context)
        {
            return source.Status.Name;
        }
    }

    public class ThreatTypeResolver : IValueResolver<Threat, Referer, string>
    {
        public string Resolve(Threat source, Referer destination, string destMember, ResolutionContext context)
        {
            return source.Status.Name;
        }
    }
}

