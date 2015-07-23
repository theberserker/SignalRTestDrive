using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace SignalRTestDrive.MVC.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            if (Context.User != null && Context.User.Identity != null && !string.IsNullOrWhiteSpace(Context.User.Identity.Name))
            {
                name = Context.User.Identity.Name;
            }
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }

    }
}