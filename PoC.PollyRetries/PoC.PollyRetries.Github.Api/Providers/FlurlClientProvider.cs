using Flurl.Http;
using PoC.PollyRetries.Github.Api.Extensions;
using PoC.PollyRetries.Github.Api.Interfaces;

namespace PoC.PollyRetries.Github.Api.Providers
{
    public class FlurlClientProvider : IApiClient
    {
        private readonly FlurlClient _client = new();

        public FlurlClientProvider()
        {
            _client.WithHeader("User-Agent", "request");
        }

        public async Task<string> GetRequestAsync(string url)
        {
            var response = await _client.GetDataAsync(url);

            return await response.GetStringAsync();
        }
    }
}
