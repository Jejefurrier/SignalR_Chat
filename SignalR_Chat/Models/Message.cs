using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace SignalR_Chat.Models
{
    public class Message
    {
        public string ChatName { get; set; }
        public string Username { get; set; }
        public string TextMessage { get; set; }
    }
}
