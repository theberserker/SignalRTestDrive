using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRTestDrive.MVC
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