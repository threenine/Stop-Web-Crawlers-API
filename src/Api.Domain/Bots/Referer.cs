using System;
using Api.Database.Entity.Threats;
using AutoMapper;
using Threenine.Map;


namespace Api.Domain.Bots
{
 public class Referer   : ICustomMap
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        
        public void CustomMap(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Threat, Referer>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Referer))
                 .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Name))
                 .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Name));
        }
    }
    
}

