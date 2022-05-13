using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nyein.Startup))]
namespace Nyein
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
