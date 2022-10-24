namespace WebApi.Hubs
{
    public interface IMessageHubClient
    {
        Task SendOffersToUser(List<string> message);
    }
}
