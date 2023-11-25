namespace PoC.PollyRetries.Github.Api.Interfaces
{
    public interface IApiClientProviderFactory
    {
        IApiClient CreateApiClientProvider(bool useFlurl = false);
    }
}