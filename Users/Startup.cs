using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Users.Startup))]
namespace Users
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
