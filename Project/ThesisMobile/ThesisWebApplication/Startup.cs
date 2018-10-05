using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThesisWebApplication.Startup))]
namespace ThesisWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
