using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EveMarket.Web.Startup))]
namespace EveMarket.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
