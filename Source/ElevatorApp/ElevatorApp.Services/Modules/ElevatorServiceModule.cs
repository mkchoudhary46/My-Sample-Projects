using Autofac;

namespace ElevatorApp.Services.Modules
{
    public class ElevatorServiceModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof (ElevatorService).Assembly).Where(t=>
                    t.Name.EndsWith("Service")
                    ).AsImplementedInterfaces();
        }
    }
}
