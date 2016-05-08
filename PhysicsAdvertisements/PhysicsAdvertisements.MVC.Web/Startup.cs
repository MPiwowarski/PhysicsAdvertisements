using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhysicsAdvertisements.MVC.Web.Startup))]
namespace PhysicsAdvertisements.MVC.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
