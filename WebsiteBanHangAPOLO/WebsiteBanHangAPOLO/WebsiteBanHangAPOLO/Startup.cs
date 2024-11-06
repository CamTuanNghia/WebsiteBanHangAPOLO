using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebsiteBanHangAPOLO.Startup))]
namespace WebsiteBanHangAPOLO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
