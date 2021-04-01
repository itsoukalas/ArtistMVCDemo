using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArtistMVCDemo.Startup))]
namespace ArtistMVCDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
