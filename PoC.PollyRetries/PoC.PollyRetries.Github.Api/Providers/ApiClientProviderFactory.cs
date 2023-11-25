using PoC.PollyRetries.Github.Api.Interfaces;

namespace PoC.PollyRetries.Github.Api.Providers
{
    public class ApiClientProviderFactory : IApiClientProviderFactory
    {
        public IApiClient CreateApiClientProvider(bool useFlurl)
            => useFlurl ? new FlurlClientProvider() : new HttpClientProvider();
    }
}
