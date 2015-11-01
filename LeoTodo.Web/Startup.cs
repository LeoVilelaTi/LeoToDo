using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeoTodo.Web.Startup))]
namespace LeoTodo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
