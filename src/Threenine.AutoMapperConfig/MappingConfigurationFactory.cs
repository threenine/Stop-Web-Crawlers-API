using System;
using PhilosophicalMonkey;
using AutoMapper;
using System.Linq;
using System.Collections.Generic;


namespace Threenine.AutoMapperConfig
{
    /*
     *      To use this simply place the following below 
     *      
     *      
     *      var seedTypes = new Type[] { typeof(Portal.Domain.Marker) };
            var assemblies = Reflect.OnTypes.GetAssemblies(seedTypes);
            var typesInAssemblies = Reflect.OnTypes.GetAllExportedTypes(assemblies);
            MappingConfigurationFactory.LoadAllMappings(typesInAssemblies);
     * 
     * 
     */


    public class MappingConfigurationFactory
    {
        public static MapperConfiguration CreateConfiguration(IList<Type> types)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
             {
                 LoadAllMappings(cfg, types);
             });


            return config;
        }


        public static void LoadAllMappings(IList<Type> types)
        {
            Mapper.Initialize(
                 cfg =>
                 {
                     LoadStandardMappings(cfg, types);
                     LoadCustomMappings(cfg, types);
                 });
        }


        public static void LoadAllMappings(IMapperConfigurationExpression config, IList<Type> types)
        {
            LoadStandardMappings(config, types);
            LoadCustomMappings(config, types);
        }


        public static void LoadCustomMappings(IMapperConfigurationExpression config, IList<Type> types)
        {
            var instancesToMap = (from t in types
                                  from i in Reflect.OnTypes.GetInterfaces(t)
                                  where Reflect.OnTypes.IsAssignable(t, typeof(IHaveCustomMappings)) &&
                                        !Reflect.OnTypes.IsAbstract(t) &&
                                        !Reflect.OnTypes.IsInterface(t)
                                  select InitializeCustomMappingObject(t)).ToArray();


            foreach (var map in instancesToMap)
            {
                map.CreateMappings(config);
            }
        }

        private static IHaveCustomMappings InitializeCustomMappingObject(Type t)
        {
            return (IHaveCustomMappings)Activator.CreateInstance(t, true);
        }


        public static void LoadStandardMappings(IMapperConfigurationExpression config, IList<Type> types)
        {
            var mapsFrom = (from t in types
                            from i in Reflect.OnTypes.GetInterfaces(t)
                            where Reflect.OnTypes.IsGenericType(i) && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                                  !Reflect.OnTypes.IsAbstract(t) &&
                                  !Reflect.OnTypes.IsInterface(t)
                            select new
                            {
                                Source = Reflect.OnTypes.GetGenericArguments(i).First(),
                                Destination = t
                            }).ToArray();


            foreach (var map in mapsFrom)
            {
                config.CreateMap(map.Source, map.Destination);
            }


            var mapsTo = (from t in types
                          from i in Reflect.OnTypes.GetInterfaces(t)
                          where Reflect.OnTypes.IsGenericType(i) && i.GetGenericTypeDefinition() == typeof(IMapTo<>) &&
                                !Reflect.OnTypes.IsAbstract(t) &&
                                !Reflect.OnTypes.IsInterface(t)
                          select new
                          {
                              Source = t,
                              Destination = Reflect.OnTypes.GetGenericArguments(i).First()
                          }).ToArray();


            foreach (var map in mapsTo)
            {
                config.CreateMap(map.Source, map.Destination);
            }


        }

    }
}


