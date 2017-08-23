namespace CRUD_AngularJs_ASPNET_MVC.Models
{
    public class BaseModel
    {
        public string Environment { get; set; }

        public string CacheBuster { get; set; }

        public string Version { get; set; }

        public string EnableMinified { get; set; }

        public string SessionId { get; set; }

        public string GaKey { get; set; }

        public string ScriptPath { get; set; }

        public string TemplatePath { get; set; }
    }
}
