using Autofac;

namespace ElevatorApp.Repositories.Modules
{
    public class ElevatorRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof (ElevatorRepository).Assembly)
                .Where(t=>
                    t.Name.EndsWith("Repository")).AsImplementedInterfaces();
            builder.RegisterType<ElevatorDataContext>().AsImplementedInterfaces();
        }
    }
}
