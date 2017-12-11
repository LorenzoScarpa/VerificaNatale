using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ziggy.Startup))]
namespace Ziggy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
