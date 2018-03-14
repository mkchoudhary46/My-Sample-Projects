using AutoMapper;
using RocketLauncherApp.DAO;
using RocketLauncherApp.Models;

namespace RocketLauncherApp.Mappers
{
    public class SatelliteMapper : IMapper
    {
        public void CreateMap()
        {
            Mapper.CreateMap<SatelliteViewModel, Satellite>()
                .ForMember(x => x.Rocket, opt => opt.Ignore())
                .ForMember(x => x.SatelliteCategory, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
