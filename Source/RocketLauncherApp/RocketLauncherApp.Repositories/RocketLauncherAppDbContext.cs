using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RocketLauncherApp.DAO;

namespace RocketLauncherApp.Repositories
{
    public class RocketLauncherAppDbContext : DbContext, IRocketLauncherAppDbContext
    {
        static RocketLauncherAppDbContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<RocketLauncherAppDbContext>());
        }

        public RocketLauncherAppDbContext()
            : base("name=RocketLauncherAppConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        public DbSet<Rocket> Rockets { get; set; }
        public DbSet<Satellite> Satellites { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<SatelliteCategory> SatelliteCategories { get; set; }
    }
}
