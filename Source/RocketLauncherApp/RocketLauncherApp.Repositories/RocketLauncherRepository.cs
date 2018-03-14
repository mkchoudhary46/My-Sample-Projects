using System.Collections.Generic;
using System.Linq;
using RocketLauncherApp.DAO;

namespace RocketLauncherApp.Repositories
{
    public class RocketLauncherRepository : IRocketLauncherRepository
    {
        private readonly IRocketLauncherAppDbContext _rocketLauncherAppDbContext;

        public RocketLauncherRepository(IRocketLauncherAppDbContext rocketLauncherAppDbContext)
        {
            _rocketLauncherAppDbContext = rocketLauncherAppDbContext;
        }

        public IEnumerable<Rocket> GetAllRockets()
        {
            return _rocketLauncherAppDbContext.Rockets.Where(x => x.IsActive);
        }

        public void CreateRocket(Rocket rocket)
        {
            _rocketLauncherAppDbContext.Rockets.Add(rocket);
            _rocketLauncherAppDbContext.SaveChanges();
        }

        public void AddSatelliteRange(IEnumerable<Satellite> satellites)
        {
            _rocketLauncherAppDbContext.Satellites.AddRange(satellites);
            _rocketLauncherAppDbContext.SaveChanges();
        }

        public void AddSatellite(Satellite satellite)
        {
            _rocketLauncherAppDbContext.Satellites.Add(satellite);
            _rocketLauncherAppDbContext.SaveChanges();
        }

        public Satellite UpdateSatellite(Satellite satellite)
        {
            var existing = _rocketLauncherAppDbContext.Satellites.FirstOrDefault(x => x.Id == satellite.Id);
            if (existing!=null)
            {
                existing.IsActive = satellite.IsActive;
                existing.Name = satellite.Name;
                existing.RocketId = satellite.RocketId;
            }
            _rocketLauncherAppDbContext.SaveChanges();
            return existing;
        }

        public IEnumerable<Satellite> GetSatellitesByRocketId(int rocketId)
        {
            var satellites = _rocketLauncherAppDbContext.Satellites.Where(x => x.Id == rocketId);
            return satellites;
        }

        public IEnumerable<Satellite> GetByCategory(int categoryId)
        {
            return _rocketLauncherAppDbContext.Satellites.Where(x => x.SatelliteCategoryId == categoryId);
        }

        public void UpdateRocketDestination(int rocketId, int destinationId)
        {
            var existingRocket = _rocketLauncherAppDbContext.Rockets.FirstOrDefault(x => x.Id == rocketId);
            if (existingRocket != null) existingRocket.DestinationId = destinationId;
            _rocketLauncherAppDbContext.SaveChanges();
        }
    }
}
