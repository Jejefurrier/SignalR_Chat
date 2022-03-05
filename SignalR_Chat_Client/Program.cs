// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using Microsoft.AspNetCore.SignalR.Client;
using SignalR_Chat_Client;

while (true)
{
    Console.WriteLine("Welcome to SignalR_Chat, please tell me your nickname!");
    var userName = Console.ReadLine();

    Console.WriteLine("Please tell me the room you want to join!");
    var chatName = Console.ReadLine();
    Console.WriteLine("If you want to leave this room, type /quit");
    HubConnection connection;
       connection = new HubConnectionBuilder()
        .WithUrl("https://localhost:44320/chat")
        .Build();

    connection.Closed += async (error) =>
    {
        await Task.Delay(new Random().Next(0, 5) * 1000);
        await connection.StartAsync();
    };

    connection.On<Message>("MessageReceived", (message) =>
    {
        Console.WriteLine(message.Username + ": " + message.TextMessage);
    });

    await connection.StartAsync();

    await connection.InvokeAsync("JoinChat", chatName);



    while (true)
    {
        var message = Console.ReadLine();
        if (message == "/quit")
        {
            await connection.InvokeAsync("LeaveChat", chatName);
            Console.WriteLine("You left " + chatName);
            break;
        }
        else
        {
            await connection.InvokeAsync("SendMessage", new Message()
            {
                ChatName = chatName,
                TextMessage = message,
                Username = userName
            });
        }
    };
}