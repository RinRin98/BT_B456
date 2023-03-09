using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_2090694912_NguyenXuanToan_BigSchool.Startup))]
namespace _2090694912_NguyenXuanToan_BigSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
