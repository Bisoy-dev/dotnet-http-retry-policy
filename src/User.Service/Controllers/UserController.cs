using Microsoft.AspNetCore.Mvc;
using User.Service.Services;

namespace User.Service.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly IOrderService _orderService;
    public UserController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var res = await _orderService.GetAll();
        Console.WriteLine(res.IsSuccessStatusCode ? "Success" : "Failed");
        return res.IsSuccessStatusCode ? Ok() : BadRequest();
    }
}