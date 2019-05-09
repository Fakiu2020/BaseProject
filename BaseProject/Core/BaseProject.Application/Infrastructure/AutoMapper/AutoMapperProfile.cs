using AutoMapper;
using System.Reflection;

namespace BaseProject.Application.Infrastructure.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            LoadStandardMappings();
            LoadCustomMappings();
            LoadConverters();
        }

        private void LoadConverters()
        {

        }

        private void LoadStandardMappings()
        {
            var maps = MapperProfileHelper.LoadStandardMappings(Assembly.GetExecutingAssembly());
            var mapsFrom = MapperProfileHelper.LoadStandardMappingsFrom(Assembly.GetExecutingAssembly());
            var mapsTo = MapperProfileHelper.LoadStandardMappingsTo(Assembly.GetExecutingAssembly());

            foreach (var map in maps)
            {
                CreateMap(map.Source, map.Destination).ReverseMap();
            }

            foreach (var map in mapsFrom)
            {
                CreateMap(map.Source, map.Destination);
            }

            foreach (var map in mapsTo)
            {
                CreateMap(map.Source, map.Destination);
            }
        }

        private void LoadCustomMappings()
        {
            var mapsFrom = MapperProfileHelper.LoadCustomMappings(Assembly.GetExecutingAssembly());

            foreach (var map in mapsFrom)
            {
                map.CreateMappings(this);
            }
        }
    }
}
