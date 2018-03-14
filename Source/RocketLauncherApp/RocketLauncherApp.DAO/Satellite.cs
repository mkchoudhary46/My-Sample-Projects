using System.ComponentModel.DataAnnotations.Schema;

namespace RocketLauncherApp.DAO
{
    public class Satellite
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int RocketId { get; set; }
        public int SatelliteCategoryId { get; set; }
        public string Name { get; set; }
        
        [ForeignKey("RocketId")]
        public virtual Rocket Rocket { get; set; }
        
        [ForeignKey("SatelliteCategoryId")]
        public virtual SatelliteCategory SatelliteCategory { get; set; }
    }
}
