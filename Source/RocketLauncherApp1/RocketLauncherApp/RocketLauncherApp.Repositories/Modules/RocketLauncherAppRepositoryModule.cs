using Autofac;

namespace RocketLauncherApp.Repositories.Modules
{
    public class RocketLauncherAppRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(RocketLauncherRepository).Assembly)
                .Where(t =>
                    t.Name.EndsWith("Repository")).AsImplementedInterfaces();
            builder.RegisterType<RocketLauncherAppDbContext>().AsImplementedInterfaces();
        }
    }
}
