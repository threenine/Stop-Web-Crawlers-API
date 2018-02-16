using System;
using System.Runtime.CompilerServices;
using Api.Database.Entity.Threats;
using AutoMapper;
using Threenine.Map;


namespace Api.Domain.Bots
{
    public class Referrer : ICustomMap
    {
        public string Identifier { get; set; }
        public string Referer { get; set; }

        public string Host { get; set; }

        public string UserAgent { get; set; }

        public string XForwardHost { get; set; }

        public string XForwardProto { get; set; }

        public string QueryString { get; set; }

        public string Protocol { get; set; }


        public void CustomMap(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Threat, Referrer>()
                .ForMember(dest => dest.Identifier, opt => opt.MapFrom(src => src.Identifier))
                .ForMember(dest => dest.Referer, opt => opt.MapFrom(src => src.Referer))
                .ForMember(dest => dest.Host, opt => opt.MapFrom(src => src.Host))
                .ForMember(dest => dest.UserAgent, opt => opt.MapFrom(src => src.UserAgent))
                .ForMember(dest => dest.XForwardHost, opt => opt.MapFrom(src => src.XForwardHost))
                .ForMember(dest => dest.XForwardProto, opt => opt.MapFrom(src => src.XForwardProto))
                .ForMember(dest => dest.QueryString, opt => opt.MapFrom(src => src.QueryString))
                .ForMember(dest => dest.Protocol, opt => opt.MapFrom(src => src.Protocol))
                .ReverseMap();
        }
    }
}