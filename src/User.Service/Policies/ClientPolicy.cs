using Polly;
using Polly.Retry;

namespace User.Service.Policies;

public class ClientPolicy
{
    public AsyncRetryPolicy<HttpResponseMessage> ImmedaiteHttpRetry { get; set; }
    public AsyncRetryPolicy<HttpResponseMessage> LinearHttpRetry { get; set; } 
    public AsyncRetryPolicy<HttpResponseMessage> ExponentialHttpRetry { get; }
    public ClientPolicy()
    {
        // if the server response an error client request again immedaitely (5x)
        ImmedaiteHttpRetry = Policy.HandleResult<HttpResponseMessage>(
            (res) => {
                return !res.IsSuccessStatusCode;
            }).RetryAsync(5);

        // if the server response an error client request again after 3 seconds delay (5x)
        LinearHttpRetry = Policy.HandleResult<HttpResponseMessage>(res => !res.IsSuccessStatusCode).WaitAndRetryAsync(5, retry => TimeSpan.FromSeconds(3));

        // seconds -  exponential of retryCount Math.Pow(2, retryCount)
        // if the server response an error client request again after second depends on what number generated from Math.Pow(2, retryCount)
        ExponentialHttpRetry = Policy.HandleResult<HttpResponseMessage>(res => !res.IsSuccessStatusCode).WaitAndRetryAsync(5, retryCount => TimeSpan.FromSeconds(Math.Pow(2, retryCount)));
    }
}