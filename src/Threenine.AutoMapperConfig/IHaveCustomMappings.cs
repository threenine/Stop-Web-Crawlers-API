using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Threenine.AutoMapperConfig
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
