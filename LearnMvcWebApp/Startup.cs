using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearnMvcWebApp.Startup))]
namespace LearnMvcWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
