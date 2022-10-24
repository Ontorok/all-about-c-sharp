using Microsoft.AspNetCore.SignalR;

namespace WebApi.Hubs
{
    public class MessageHub : Hub<IMessageHubClient>
    {
        public async Task SendOfferToUser(List<string> message)
        {
            await Clients.All.SendOffersToUser(message);
        }
    }
}
