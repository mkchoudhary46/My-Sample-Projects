using System.Data.Entity;
using RocketLauncherApp.DAO;

namespace RocketLauncherApp.Repositories
{
    public interface IRocketLauncherAppDbContext
    {
        DbSet<Rocket> Rockets { get; set; }
        DbSet<Satellite> Satellites { get; set; }
        DbSet<SatelliteCategory> SatelliteCategories { get; set; }
        DbSet<Destination> Destinations { get; set; }
        int SaveChanges();
    }
}
