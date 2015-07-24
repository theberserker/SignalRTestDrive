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
            
            app.MapSignalR(); // the hub part registration (at /signalr)

            app.MapSignalR<UsersConnection>("/echo"); // the persistent connection registration

            

        }
    }
}
