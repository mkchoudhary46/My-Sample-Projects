using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using LifeLine.Services;
using LifeLine.Web.Infrastructure.Modules;

namespace LifeLine.Web
{
    public class AutoFacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register dependencies in controllers

            // Register our Data dependencies
            builder.RegisterAssemblyModules(typeof(ServiceModule).Assembly, Assembly.GetExecutingAssembly(),
                typeof (IBloodDonorService).Assembly);

            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}