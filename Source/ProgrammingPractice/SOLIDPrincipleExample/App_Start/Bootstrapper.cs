//using System.Reflection;
//using System.Web.Http;
//using System.Web.Mvc;
//using Autofac;
//using Autofac.Integration.Mvc;
//using Autofac.Integration.WebApi;
//using Microsoft.Owin;
//using Owin;
//using SOLIDPrincipleExample;
//using SOLIDPrincipleExample.Infrastructure.Modules;

//[assembly: OwinStartup(typeof(Startup))]
//namespace SOLIDPrincipleExample
//{
//    public class Startup
//    {
//        public void Configuration(IAppBuilder app)
//        {
//            var builder = new ContainerBuilder();

//            builder.RegisterAssemblyModules<DatabaseModule>(Assembly.GetExecutingAssembly());
//            builder.RegisterAssemblyModules<RepositoryModule>(Assembly.GetExecutingAssembly());
//            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
//            builder.RegisterControllers(Assembly.GetExecutingAssembly());
//            var container = builder.Build();
//            DependencyResolver.SetResolver(new AutofacDependencyResolver(container) );
//            var resolver = new AutofacWebApiDependencyResolver(container);
//            GlobalConfiguration.Configuration.DependencyResolver = resolver;
//            var config = GlobalConfiguration.Configuration;

//        }

//    }
//}