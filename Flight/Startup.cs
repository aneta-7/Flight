using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Flights.Startup))]
namespace Flights
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
