using Microsoft.AspNetCore.SignalR;
using SignalR_Chat.Models;

namespace SignalR_Chat.Hubs
{
    public class ChatHub : Hub
    {

        public Task JoinChat(string chatName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, chatName);
        }

        public Task LeaveChat(string chatName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, chatName);
        }

        public Task SendMessage(Message message)
        {
            return Clients.Group(message.ChatName).SendAsync("MessageReceived", message);
        }
    }
}
