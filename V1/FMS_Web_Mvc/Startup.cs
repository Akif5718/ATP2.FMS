using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FMS_Web_Mvc.Startup))]
namespace FMS_Web_Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
