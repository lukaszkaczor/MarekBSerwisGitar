using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SerwisGitar.Startup))]
namespace SerwisGitar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
