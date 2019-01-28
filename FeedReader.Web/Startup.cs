using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FeedReader.Web.Startup))]
namespace FeedReader.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
