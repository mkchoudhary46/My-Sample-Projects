using System;
using System.Linq;
using System.Reflection;
using Autofac;
using ElevatorApp.Mappers;
using ElevatorApp.Repositories;
using ElevatorApp.Services;

namespace ElevatorApp
{
    public class AutofacRegistration
    {
        public static IContainer ConfigureContainer()
        {
            InitMappingConfig();
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyModules(typeof(ElevatorService).Assembly);
            builder.RegisterAssemblyModules(typeof(ElevatorRepository).Assembly);
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
