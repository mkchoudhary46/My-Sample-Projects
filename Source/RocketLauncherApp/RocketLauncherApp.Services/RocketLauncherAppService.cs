using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RocketLauncherApp.DAO;
using RocketLauncherApp.Models;
using RocketLauncherApp.Repositories;

namespace RocketLauncherApp.Services
{
    public class RocketLauncherAppService : IRocketLauncherAppService
    {
        private readonly IRocketLauncherRepository _rocketLauncherRepository;

        public RocketLauncherAppService(IRocketLauncherRepository rocketLauncherRepository)
        {
            _rocketLauncherRepository = rocketLauncherRepository;
        }

        public IEnumerable<int> GetAllRocketIds()
        {
            return _rocketLauncherRepository.GetAllRockets().Select(x => x.Id);
        }

        public void CreateRocket(RocketViewModel rocket)
        {
            var rocketDao = Mapper.Map<Rocket>(rocket);
            _rocketLauncherRepository.CreateRocket(rocketDao);
        }

        public void AddSatellites(IEnumerable<SatelliteViewModel> satellites)
        {
            var satellitesDao = Mapper.Map<IEnumerable<Satellite>>(satellites);
            _rocketLauncherRepository.AddSatelliteRange(satellitesDao);
        }

        public void AddSatellite(SatelliteViewModel satellite)
        {
            var dao = Mapper.Map<Satellite>(satellite);
            _rocketLauncherRepository.AddSatellite(dao);
        }

        public SatelliteViewModel UpdateSatellite(SatelliteViewModel satellite)
        {
            var dao = Mapper.Map<Satellite>(satellite);
            var updatedSatellite = _rocketLauncherRepository.UpdateSatellite(dao);
            return Mapper.Map<SatelliteViewModel>(updatedSatellite);
        }

        public IEnumerable<SatelliteViewModel> GetSatellitesByRocketId(int rocketId)
        {
            var satelliteList = _rocketLauncherRepository.GetSatellitesByRocketId(rocketId);
            return Mapper.Map<IEnumerable<SatelliteViewModel>>(satelliteList);
        }

        public IEnumerable<SatelliteViewModel> GetSatellitesByCategoryId(int categoryId)
        {
            var satelliteList = _rocketLauncherRepository.GetByCategory(categoryId);
            return Mapper.Map<IEnumerable<SatelliteViewModel>>(satelliteList);
        }
    }
}
