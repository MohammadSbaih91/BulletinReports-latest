using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BulletinReports.Startup))]
namespace BulletinReports
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
