namespace PoC.PollyRetries.Github.Api.Interfaces
{
    public interface IApiClient
    {
        Task<string> GetRequestAsync(string url);
    }
}
