using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LifeLine.Startup))]
namespace LifeLine
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
