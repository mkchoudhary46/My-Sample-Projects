using Autofac;

namespace RocketLauncherApp.Services.Modules
{
    class RocketLauncherAppServiceModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(RocketLauncherAppService).Assembly).Where(t =>
                    t.Name.EndsWith("Service")
                    ).AsImplementedInterfaces();
        }
    }


}
