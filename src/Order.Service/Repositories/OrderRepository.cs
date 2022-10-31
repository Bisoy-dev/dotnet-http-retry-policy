namespace Order.Service.Repositories;

public class OrderRepository
{
    private readonly IDictionary<int, string> orders = new Dictionary<int, string>
        {
            {1, "Order - 1"}, {2, "Order - 2"}, {3, "Order - 3"}, {4, "Order - 4"}
        }; 
    
    public IDictionary<int, string> GetAll()
    {
        return orders;
    }
    public string Get(int key)
    {
        string value = orders[key].ToString();
        return value;
    }
}