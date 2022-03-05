using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Chat_Client
{
    public class Message
    {
        public string ChatName { get; set; }
        public string Username { get; set; }
        public string TextMessage { get; set; }
    }
}
