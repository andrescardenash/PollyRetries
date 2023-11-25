using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

namespace PoC.PollyRetries.Github.Api.Policies
{
    public static class HttpClientPollyRetryPolicy
    {
        private static readonly AsyncRetryPolicy<HttpResponseMessage> _asyncRetryPolicy;

        public static AsyncRetryPolicy<HttpResponseMessage> AsyncRetryPolicy => _asyncRetryPolicy;

        static HttpClientPollyRetryPolicy()
        {
            _asyncRetryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync
                (
                    retryCount: 3,
                    count => TimeSpan.FromSeconds(1 * count), 
                    onRetry: (exception, retryTime, retryNumber, context) =>
                    {
                        Console.WriteLine($"exception: {exception?.Exception?.Message}.");
                        Console.WriteLine($"Retry {retryNumber} of 3 after retry time: {retryTime.TotalMilliseconds}ms.");
                    }
                );
        }
    }
}
