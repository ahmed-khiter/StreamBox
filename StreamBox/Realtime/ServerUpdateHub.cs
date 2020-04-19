using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace StreamBox.Realtime
{
    public class ServerUpdateHub : Hub
    {
        public async Task SendMessage(int serverId)
        {
            await Clients.All.SendAsync("Update", serverId);
        }
    }
}