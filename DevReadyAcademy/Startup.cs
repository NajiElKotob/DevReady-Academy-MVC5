using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DevReadyAcademy.Startup))]
namespace DevReadyAcademy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
