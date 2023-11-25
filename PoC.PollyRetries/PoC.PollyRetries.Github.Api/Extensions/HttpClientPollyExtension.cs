using PoC.PollyRetries.Github.Api.Policies;

namespace PoC.PollyRetries.Github.Api.Extensions
{
    public static class HttpClientPollyExtension
    {
        public static async Task<HttpResponseMessage> GetDataAsync(this HttpClient client, string url)
        {
            return await HttpClientPollyRetryPolicy.AsyncRetryPolicy.ExecuteAsync(async () =>
            {
                //var result = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
                var result = await client.GetAsync(url);

                return result;
            });
        }
    }
}
