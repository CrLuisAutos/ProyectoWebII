using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(roles.Startup))]
namespace roles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
