using System.Collections.Generic;
using RocketLauncherApp.Models;

namespace RocketLauncherApp.Services
{
    public interface IRocketLauncherAppService
    {
        IEnumerable<int> GetAllRocketIds(); 
        void CreateRocket(RocketViewModel rocket);
        void AddSatellites(IEnumerable<SatelliteViewModel> satellites);
        void AddSatellite(SatelliteViewModel satellites);
        SatelliteViewModel UpdateSatellite(SatelliteViewModel satellite);
        IEnumerable<SatelliteViewModel> GetSatellitesByRocketId(int rocketId);
        IEnumerable<SatelliteViewModel> GetSatellitesByCategoryId(int categoryId);
    }
}
