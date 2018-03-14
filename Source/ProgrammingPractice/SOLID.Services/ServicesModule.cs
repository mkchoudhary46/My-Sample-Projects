using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace SOLID.Services
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IProductService).Assembly)
                .Where(x => x.Name.EndsWith("Services"))
                .AsImplementedInterfaces();
        }
    }
}