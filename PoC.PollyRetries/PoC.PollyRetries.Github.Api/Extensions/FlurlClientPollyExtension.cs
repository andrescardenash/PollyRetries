using Flurl.Http;
using PoC.PollyRetries.Github.Api.Policies;

namespace PoC.PollyRetries.Github.Api.Extensions
{
    public static class FlurlClientPollyExtension
    {
        public static async Task<IFlurlResponse> GetDataAsync(this FlurlClient client, string url)
        {
            return await FlurlClientPollyRetryPolicy.AsyncRetryPolicy.ExecuteAsync(async () =>
            {
                var response = await url
                                .WithClient(client)
                                .GetAsync();
                return response;
            });
        }
    }
}
