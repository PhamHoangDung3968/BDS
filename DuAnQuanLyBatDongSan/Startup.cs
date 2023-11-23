using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DuAnQuanLyBatDongSan.Startup))]
namespace DuAnQuanLyBatDongSan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
