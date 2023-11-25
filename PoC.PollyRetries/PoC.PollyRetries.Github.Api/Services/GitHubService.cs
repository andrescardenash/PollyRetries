using PoC.PollyRetries.Github.Api.Interfaces;

namespace PoC.PollyRetries.Github.Api.Services
{
    public class GitHubService : IGithubService
    {
        private const string BASE_ADDRESS = "https://api.github.com";
        private readonly IApiClient _apiClient;

        public GitHubService(IApiClientProviderFactory apiClientProviderFactory)
        {
            _apiClient = apiClientProviderFactory.CreateApiClientProvider(true);
        }

        public async Task<string> GetUserByName(string userName)
        {
            var response = await _apiClient.GetRequestAsync($"{BASE_ADDRESS}/users/{userName}");

            return response;
        }
    }
}
