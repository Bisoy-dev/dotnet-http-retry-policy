using User.Service.Policies;

namespace User.Service.Services;

public class OrderService : IOrderService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly ClientPolicy _clientPolicy;
    private const string url = "https://localhost:7269";
    public OrderService(IHttpClientFactory clientFactory, ClientPolicy clientPolicy)
    {
        _clientFactory = clientFactory;
        _clientPolicy = clientPolicy;
    }
    public Task<string> Get(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<HttpResponseMessage> GetAll()
    {
        var client = _clientFactory.CreateClient();

        var response = await _clientPolicy.ExponentialHttpRetry.ExecuteAsync(() => client.GetAsync($"{url}/order"));
        
        return response;
    }
}