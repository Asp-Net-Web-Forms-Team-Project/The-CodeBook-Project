using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheCodeBookProject.Web.App.Startup))]
namespace TheCodeBookProject.Web.App
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
