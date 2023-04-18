namespace QuoteHub
{
    public interface IQuoteHubClient
    {
        Task ReceiveMessage(string message);
    }
}
