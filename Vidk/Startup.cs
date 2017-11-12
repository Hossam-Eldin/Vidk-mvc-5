using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidk.Startup))]
namespace Vidk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
