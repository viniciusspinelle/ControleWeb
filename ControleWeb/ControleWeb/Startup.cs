using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ControleWeb.Startup))]
namespace ControleWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
