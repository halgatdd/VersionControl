using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(UnitTestExample.Testt.StartupOwin))]

namespace UnitTestExample.Testt
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
