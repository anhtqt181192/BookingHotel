using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WebsiteBookingHotel.SignalR
{
    public class DemoHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
