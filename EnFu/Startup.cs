using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EnFu.Startup))]
namespace EnFu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
