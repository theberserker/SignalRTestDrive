using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using SignalRTestDrive.MVC.Helpers;

namespace SignalRTestDrive.MVC.Infrastructure
{
    public class ConnectedUsersManager
    {
        /// <summary>
        /// Contains a list of all users sessions.
        /// </summary>
        private static readonly ConnectedUsersRepository Repository = new ConnectedUsersRepository();

        public void AddNewConection(IRequest request, string connectionId)
        {
            string uid = GetUniqueId(request);
            Repository.Add(uid, connectionId);
        }

        public void RemoveConnection(IRequest request, string connectionId)
        {
            string uid = GetUniqueId(request);
            Repository.Remove(uid, connectionId);
        }

        public string GetUniqueId(IRequest request)
        {
            if (!request.Cookies.ContainsKey(Consts.UniqieIdCookieName))
            {
                throw new Exception("Wait, we should have the cookie already!");
            }

            var cookie = request.Cookies[Consts.UniqieIdCookieName];

            var uid = PersistentCookieHelper.Decrypt(cookie);

            return uid;
        }

        internal ConcurrentDictionary<string, IList<string>> GetAll()
        {
            return Repository.ConnectedUsers;
        }
    }
}
