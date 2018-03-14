using Autofac;

namespace RocketLauncherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = AutofacRegistration.ConfigureContainer();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }
        }
    }
}
