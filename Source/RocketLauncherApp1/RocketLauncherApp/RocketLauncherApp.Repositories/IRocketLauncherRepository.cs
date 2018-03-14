using System.Collections.Generic;
using RocketLauncherApp.DAO;

namespace RocketLauncherApp.Repositories
{
    public interface IRocketLauncherRepository
    {
        IEnumerable<Rocket> GetAllRockets(); 
        void CreateRocket(Rocket rocket);
        void AddSatelliteRange(IEnumerable<Satellite> satellites);
        void AddSatellite(Satellite satellite);
        Satellite UpdateSatellite(Satellite satellite);
        IEnumerable<Satellite> GetSatellitesByRocketId(int rocketId);
        IEnumerable<Satellite> GetByCategory(int categoryId);
        void UpdateRocketDestination(int rocketId, int destinationId);
    }
}
