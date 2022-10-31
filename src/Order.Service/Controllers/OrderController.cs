using Microsoft.AspNetCore.Mvc;
using Order.Service.Repositories;

namespace Order.Service.Controllers;

[ApiController]
[Route("order")]
public class OrderController : ControllerBase
{
    private readonly OrderRepository _orderRepository;
    public OrderController(OrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var rnd = new Random();
        int generatedValue = rnd.Next(1, 101);
        Console.WriteLine((generatedValue >= 50) ? "Success" : "Failed to return values");
        return generatedValue >= 50 ? Ok(_orderRepository.GetAll()) : BadRequest();
    } 

    [HttpGet("{userId:int}")]
    public IActionResult Get([FromRoute]int userId)
    {
        var rnd = new Random();
        int generatedValue = rnd.Next(1, 101);
        Console.WriteLine((generatedValue >= 50) ? "Success" : "Failed to return values");
        return generatedValue >= 50 ? Ok(_orderRepository.Get(userId)) : BadRequest();
    }
}
