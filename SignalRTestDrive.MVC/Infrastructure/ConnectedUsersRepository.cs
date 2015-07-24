using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRTestDrive.MVC.Infrastructure
{
    public class ConnectedUsersRepository
    {
        public readonly ConcurrentDictionary<string, IList<string>> ConnectedUsers = new ConcurrentDictionary<string, IList<string>>();

        public void Add(string uid, string connectionId)
        {
            IList<string> connections = null;
            ConnectedUsers.TryGetValue(uid, out connections);

            if (connections != null)
            {
                connections.Add(connectionId);
            }
            else
            {
                bool sucess = ConnectedUsers.TryAdd(uid, new List<string>{connectionId});

                if (!sucess)
                {
                    throw new Exception(string.Format("Something went wrong while trying to add license {0}", uid));
                }
            }   
        }

        public void Remove(string uid, string connectionId)
        {
            if (!ConnectedUsers.Keys.Contains(uid))
            {
                Trace.WriteLine(string.Format("Something strange... uid '{0}' not present", uid));
                return;
            }

            ConnectedUsers[uid].Remove(connectionId); // TODO: will this fail if connectionId not present?

            if (ConnectedUsers[uid].Count == 0)
            {
                IList<string> lRemoved;
                ConnectedUsers.TryRemove(uid, out lRemoved);
            }
        }
    }
}
