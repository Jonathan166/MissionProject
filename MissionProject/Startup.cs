using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MissionProject.Startup))]
namespace MissionProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
