using PoC.PollyRetries.Github.Api.Extensions;
using PoC.PollyRetries.Github.Api.Interfaces;

namespace PoC.PollyRetries.Github.Api.Providers
{
    public class HttpClientProvider : IApiClient
    {
        private readonly HttpClient _client = new();

        public HttpClientProvider()
        {
            _client.DefaultRequestHeaders.Add("User-Agent", "request");
        }

        public async Task<string> GetRequestAsync(string url)
        {
            var response = await _client.GetDataAsync(url);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
