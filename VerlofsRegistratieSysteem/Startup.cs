using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VerlofsRegistratieSysteem.Startup))]
namespace VerlofsRegistratieSysteem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
