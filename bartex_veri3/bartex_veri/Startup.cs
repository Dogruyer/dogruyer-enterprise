using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bartex_veri.Startup))]
namespace bartex_veri
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
