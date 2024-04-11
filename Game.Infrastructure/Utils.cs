using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;

namespace Game.Infrastructure;

public static class Utils
{
    public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(int retryCount, int retryDelay)
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.TooManyRequests) // HttpCode = 429
            .WaitAndRetryAsync(retryCount, retryAttempt => TimeSpan.FromSeconds(retryDelay));
    }
}
