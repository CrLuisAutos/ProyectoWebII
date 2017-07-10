using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoCRM.Startup))]
namespace ProyectoCRM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
