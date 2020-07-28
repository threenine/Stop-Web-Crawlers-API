using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Api.Database.Entity.Threats;
using AutoMapper;
using Threenine.Map;

namespace Api.Domain.Bots
{
  public  class AddRefererer : ICustomMap
    {
        [Required, StringLength(55)]
        public string Referer { get; set; }
        
        [Required, StringLength(256)]
        public Uri Url { get; set; }

        public void CustomMap(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<AddRefererer, Threat>()
              
                .ForMember(dest => dest.Referer, opt => opt.MapFrom(src => src.Url.AbsoluteUri))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Referer));
        }
    }
}
