using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProCore.Connector.Web.Startup))]
namespace ProCore.Connector.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
