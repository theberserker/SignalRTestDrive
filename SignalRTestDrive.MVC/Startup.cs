using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignalRTestDrive.MVC.Startup))]
namespace SignalRTestDrive.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
            app.MapSignalR();
        }
    }
}
