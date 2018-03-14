using AutoMapper;
using AutoMapper.Configuration;
using LifeLine.Core.DAO;

namespace LifeLine.Common.Mappers.Mappers
{
    public class BloodDonorMap : IMapper
    {
        public void CreateMap()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<BloodDonor, Core.ViewModels.BloodDonor>();
            });
        }
    }
}
