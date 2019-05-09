using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Whoever.Common.Mapping;

namespace BaseProject.Application.Infrastructure.AutoMapper
{
    public sealed class Map
    {
        public Type Source { get; set; }
        public Type Destination { get; set; }
    }

    public static class MapperProfileHelper
    {
        public static IList<Map> LoadStandardMappings(Assembly rootAssembly)
        {
            var types = rootAssembly.GetExportedTypes();

            var maps = (
                    from type in types
                    from instance in type.GetInterfaces()
                    where
                        instance.IsGenericType && instance.GetGenericTypeDefinition() == typeof(IMap<,>) &&
                        !type.IsAbstract &&
                        !type.IsInterface
                    select new Map
                    {
                        Source = type.GetInterfaces().First().GetGenericArguments().First(),
                        Destination = type.GetInterfaces().First().GetGenericArguments().Last()
                    }).ToList();

            return maps;
        }

        public static IList<Map> LoadStandardMappingsFrom(Assembly rootAssembly)
        {
            var types = rootAssembly.GetExportedTypes();

            var mapsFrom = (
                    from type in types
                    from instance in type.GetInterfaces()
                    where
                        instance.IsGenericType && instance.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                        !type.IsAbstract &&
                        !type.IsInterface
                    select new Map
                    {
                        Source = type.GetInterfaces()
                                .First(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IMapFrom<>))
                                .GetGenericArguments().First(),
                        Destination = type
                    }).ToList();

            return mapsFrom;
        }

        public static IList<Map> LoadStandardMappingsTo(Assembly rootAssembly)
        {
            var types = rootAssembly.GetExportedTypes();

            var mapsTo = (
                    from type in types
                    from instance in type.GetInterfaces()
                    where
                        instance.IsGenericType && instance.GetGenericTypeDefinition() == typeof(IMapTo<>) &&
                        !type.IsAbstract &&
                        !type.IsInterface
                    select new Map
                    {
                        Source = type,
                        Destination = type.GetInterfaces()
                                    .First(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IMapTo<>))
                                    .GetGenericArguments().First()
                    }).ToList();

            return mapsTo;
        }

        public static IList<IHaveCustomMapping> LoadCustomMappings(Assembly rootAssembly)
        {
            var types = rootAssembly.GetExportedTypes();

            var mapsFrom = (
                    from type in types
                    from instance in type.GetInterfaces()
                    where
                        typeof(IHaveCustomMapping).IsAssignableFrom(type) &&
                        !type.IsAbstract &&
                        !type.IsInterface
                    select (IHaveCustomMapping)Activator.CreateInstance(type)).ToList();

            return mapsFrom;
        }
    }
}
