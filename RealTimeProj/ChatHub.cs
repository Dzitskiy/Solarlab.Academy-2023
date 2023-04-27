using Microsoft.AspNetCore.SignalR;

namespace RealTimeProj
{
    public class ChatHub : Hub
    {
        //public async Task Send(string nickname, string message) 
        //{
        //    await Clients.All.SendAsync("Send",nickname, message);  
        //}

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

    }
}