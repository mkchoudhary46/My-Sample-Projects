using AutoMapper;
using RocketLauncherApp.DAO;
using RocketLauncherApp.Models;

namespace RocketLauncherApp.Mappers
{
    public class RocketMapper : IMapper
    {
        public void CreateMap()
        {
            Mapper.CreateMap<RocketViewModel, Rocket>()
                .ForMember(x => x.Satellites, opt => opt.Ignore())
                .ForMember(x => x.Destination, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
