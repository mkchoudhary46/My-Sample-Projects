using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketLauncherApp.DAO
{
    public class Rocket
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public int DestinationId { get; set; }

        [ForeignKey("DestinationId")]
        public virtual Destination Destination { get; set; }
        public virtual IEnumerable<Satellite> Satellites { get; set; }
    }
}
