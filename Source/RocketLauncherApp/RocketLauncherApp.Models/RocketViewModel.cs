using RocketLauncherApp.Common;

namespace RocketLauncherApp.Models
{
    public class RocketViewModel
    {
        public RocketViewModel()
        {
        }

        public RocketViewModel(string name)
        {
            Name = name;
            IsActive = true;
            DestinationId = (int)(Destination.Moon);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int DestinationId { get; set; }
    }
}
