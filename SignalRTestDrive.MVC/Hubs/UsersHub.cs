using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using SignalRTestDrive.MVC.Infrastructure;
using SignalRTestDrive.MVC.Models;

namespace SignalRTestDrive.MVC.Hubs
{
    public class UsersHub : Hub
    {
        private readonly ConnectedUsersManager _usersManager = new ConnectedUsersManager();

        public void Broadcast(IEnumerable<ConnectedUserViewModel> viewModels)
        {
            Clients.All.broadcastState( new { users = viewModels });
        }

        public override Task OnConnected()
        {
            _usersManager.AddNewConection(Context.Request, Context.ConnectionId);

            Broadcast(_usersManager.GetConnectedUserViewModels());

            return base.OnConnected();
        }

        public override Task OnReconnected() // TODO!
        {
            return base.OnReconnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            _usersManager.RemoveConnection(Context.Request, Context.ConnectionId);

            Broadcast(_usersManager.GetConnectedUserViewModels());

            return base.OnDisconnected(stopCalled);
        }
    }
}