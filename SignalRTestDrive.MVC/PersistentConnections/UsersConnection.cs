﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.SignalR;
using SignalRTestDrive.MVC.Helpers;
using SignalRTestDrive.MVC.Infrastructure;

namespace SignalRTestDrive.MVC.PersistentConnections
{
    public class UsersConnection : PersistentConnection
    {
        private ConnectedUsersManager _usersManager = new ConnectedUsersManager();

        protected override Task OnConnected(IRequest request, string connectionId)
        {
            _usersManager.AddNewConection(request, connectionId);

            //return Connection.Send(connectionId, _usersManager.GetAll());
            return Connection.Broadcast(_usersManager.GetConnectedUserViewModels());
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            return Connection.Broadcast(data);
        }

        protected override Task OnReconnected(IRequest request, string connectionId)
        {
            return base.OnReconnected(request, connectionId);
        }

        protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
        {
            _usersManager.RemoveConnection(request, connectionId);

            return base.OnDisconnected(request, connectionId, stopCalled);
        }
    }
}