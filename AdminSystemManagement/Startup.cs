using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdminSystemManagement.Startup))]
namespace AdminSystemManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
