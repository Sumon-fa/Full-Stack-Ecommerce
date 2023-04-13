using backend.Services;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using backend.Common;

namespace backend.Controllers;

public class OrderController : ApiControllerBase
{
    private readonly IOrderService _service;
    private readonly UserManager<User> _userManager;

    public OrderController(IOrderService service, UserManager<User> userManager)
    {
        _service = service;
        _userManager = userManager;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(OrderDTO request)
    {
        var user = await _userManager.GetUserAsync(User);

        var order = await _service.CreateAsync(request, user);
        if (order is null)
        {
            throw ServiceException.BadRequest("data is not valid");
        }

        return Ok(order);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        return Ok(await _service.GetAllAsync());
    }

    [Authorize]
    [HttpGet("myorders")]
    public async Task<IActionResult> GetMyOrders()
    {
        var user = await _userManager.GetUserAsync(User);

        return Ok(await _service.GetMyOrdersAsync(user));
    }

    [Authorize]
    [HttpGet("/order/{id:Guid}")]
    public async Task<IActionResult> GetSingleOrder(Guid id)
    {
        var user = await _userManager.GetUserAsync(User);

        return Ok(await _service.GetSingleOrderAsync(id, user));
    }

    [Authorize]
    [HttpGet("admin/order/{id:Guid}")]
    public async Task<IActionResult> GetOrderDetailsByAddmin(Guid id)
    {
        return Ok(await _service.GetOrderDetailsByAdminAsync(id));
    }
}
