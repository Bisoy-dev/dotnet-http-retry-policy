namespace User.Service.Services;

public interface IOrderService
{
    Task<HttpResponseMessage> GetAll();
    Task<string> Get(int userId);
}