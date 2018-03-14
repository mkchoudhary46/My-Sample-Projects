using System;
using System.Linq;
using System.Reflection;
using Autofac;
using RocketLauncherApp.Mappers;
using RocketLauncherApp.Repositories;
using RocketLauncherApp.Services;

namespace RocketLauncherApp
{
    public class AutofacRegistration
    {
        public static IContainer ConfigureContainer()
        {
            InitMappingConfig();
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyModules(typeof(RocketLauncherAppService).Assembly);
            builder.RegisterAssemblyModules(typeof(RocketLauncherRepository).Assembly);
            builder.RegisterType<Application>().As<IApplication>();
            return builder.Build();
        }

        public static void InitMappingConfig()
        {
            var type = typeof(IMapper);
            var types = typeof(IMapper).Assembly.GetTypes()
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface).ToList();

            types.ForEach(t =>
            {
                var n = (IMapper)Activator.CreateInstance(t);
                n.CreateMap();
            });
        }

    }
}
