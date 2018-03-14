using Autofac;
using SOLID.Repository;

namespace SOLIDPrincipleExample.Infrastructure.Modules
{
    public class DatabaseModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductContext>().As<IProductContext>()
                .InstancePerRequest();
        }
    }
}