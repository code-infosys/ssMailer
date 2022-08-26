using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ssMailer.Startup))]
namespace ssMailer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
