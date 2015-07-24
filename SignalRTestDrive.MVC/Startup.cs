using System.Web.Routing;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using SignalRTestDrive.MVC.PersistentConnections;

[assembly: OwinStartupAttribute(typeof(SignalRTestDrive.MVC.Startup))]
namespace SignalRTestDrive.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var hubConfig = new HubConfiguration() {EnableDetailedErrors = true};
            app.MapSignalR(hubConfig); // the hub part registration (at /signalr)

            app.MapSignalR<UsersConnection>("/echo"); // the persistent connection registration
        }
    }
}
