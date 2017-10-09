using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DB1.Startup))]
namespace DB1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
