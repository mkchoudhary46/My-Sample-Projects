using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUD_AngularJs_ASPNET_MVC.Startup))]
namespace CRUD_AngularJs_ASPNET_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);
        }
    }
}
