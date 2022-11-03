using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TakeMeHome.API.Shared.Extensions;
using TakeMeHome.API.TakeMeHome.Domain.Models;
using TakeMeHome.API.TakeMeHome.Domain.Services;
using TakeMeHome.API.TakeMeHome.Resources;

namespace TakeMeHome.API.TakeMeHome.Controllers;

[Route("/api/v1/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrdersController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<OrderResource>> GetAllAsync()
    {
        var orders = await _orderService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResource>>(orders);
        return resources;
    }
    
    [HttpGet]
    [Route("/status/{status_id}")]
    public async Task<IEnumerable<OrderResource>> GetByStatusIdAsync(int status_id)
    {
        var orders = await _orderService.ListByOrderStatusIdAsync(status_id);
        var resources = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResource>>(orders);
        return resources;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveOrderResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var order = _mapper.Map<SaveOrderResource, Order>(resource);
        var result = await _orderService.SaveAsync(order);

        if (!result.Success)
            return BadRequest(result.Message);

        var orderResource = _mapper.Map<Order, OrderResource>(result.Resource);
        return Ok(orderResource);
    }
}