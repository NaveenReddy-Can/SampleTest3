using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleTest3.Startup))]
namespace SampleTest3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
