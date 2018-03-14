namespace RocketLauncherApp.Models
{
    public class SatelliteViewModel
    {
        public SatelliteViewModel()
        {
        }

        public SatelliteViewModel(string name, int rocketId)
        {
            IsActive = true;
            RocketId = rocketId;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int RocketId { get; set; }
        public bool IsActive { get; set; }
        public int SatelliteCategoryId { get; set; }
    }
}
