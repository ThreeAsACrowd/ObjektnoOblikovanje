using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AccountingWeb.Startup))]
namespace AccountingWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
