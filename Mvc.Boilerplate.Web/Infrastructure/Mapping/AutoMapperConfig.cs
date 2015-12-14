using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;


//https://github.com/MattHoneycutt/Fail-Tracker

namespace Mvc.Boilerplate.Web.Infrastructure.Mapping
{
    public class AutoMapperConfig
    {
        public static void Init()
        {
            var types = Assembly.GetExecutingAssembly().GetExportedTypes();

            //Standard
            LoadStandardMappings(types);
            //Custom
            LoadCustomMappings(types);
        }


        private static void LoadCustomMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IMapSourceCustomMapping).IsAssignableFrom(t) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select (IMapSourceCustomMapping)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                map.CreateMappings(Mapper.Configuration);
            }
        }

        private static void LoadStandardMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapSource<>) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();

            foreach (var map in maps)
            {
                Mapper.CreateMap(map.Source, map.Destination);
            }
        }

    }
}