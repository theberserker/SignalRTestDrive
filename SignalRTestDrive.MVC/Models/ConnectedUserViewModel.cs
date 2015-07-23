using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRTestDrive.MVC.Models
{
    public class ConnectedUserViewModel
    {
        public string UniqueId { get; set; }
        public IList<string> Connections { get; set; }
    }
}
