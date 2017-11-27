using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Adikov.Startup))]
namespace Adikov
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
