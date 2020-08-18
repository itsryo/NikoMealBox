using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NikoMealBox.Startup))]
namespace NikoMealBox
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
