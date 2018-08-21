using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BreweryServices.Startup))]
namespace BreweryServices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
