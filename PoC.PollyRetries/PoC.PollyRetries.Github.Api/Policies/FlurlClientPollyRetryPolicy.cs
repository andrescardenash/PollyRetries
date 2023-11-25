using Flurl.Http;
using Polly;
using Polly.Retry;

namespace PoC.PollyRetries.Github.Api.Policies
{
    public static class FlurlClientPollyRetryPolicy
    {
        private static readonly AsyncRetryPolicy<IFlurlResponse> _asyncRetryPolicy;

        public static AsyncRetryPolicy<IFlurlResponse> AsyncRetryPolicy => _asyncRetryPolicy;

        static FlurlClientPollyRetryPolicy()
        {
            _asyncRetryPolicy = Policy<IFlurlResponse>
                //.Handle<FlurlHttpException>(exception =>
                //                            exception.Call.Response.StatusCode == StatusCodes.Status500InternalServerError ||
                //                            exception.Call.Response.StatusCode == StatusCodes.Status408RequestTimeout
                //                           )
                .Handle<FlurlHttpException>()
                .OrResult(result => 
                          result.StatusCode == StatusCodes.Status500InternalServerError ||
                          result.StatusCode == StatusCodes.Status408RequestTimeout
                         )
                .WaitAndRetryAsync
                (
                    retryCount: 3,
                    count => TimeSpan.FromSeconds(2 * count),
                    onRetry: (exception, retryTime, retryNumber, context) =>
                    {
                        Console.WriteLine($"exception: {exception?.Exception?.Message}.");
                        Console.WriteLine($"Retry {retryNumber} of 3 after retry time: {retryTime.TotalMilliseconds}ms.");
                    }
                );
        }
    }
}
