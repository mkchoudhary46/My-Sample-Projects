using AutoMapper;
using ElevatorApp.DAO;
using ElevatorApp.Models;

namespace ElevatorApp.Mappers
{
    public class FloorMapper: IMapper
    {
        public void CreateMap()
        {
            Mapper.CreateMap<FloorModel, Floor>()
                .ForMember(c => c.IsActive, opt => opt.Ignore())
                .ReverseMap();

        }
    }
}
