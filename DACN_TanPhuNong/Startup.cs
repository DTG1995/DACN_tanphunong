using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DACN_TanPhuNong.Startup))]
namespace DACN_TanPhuNong
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
