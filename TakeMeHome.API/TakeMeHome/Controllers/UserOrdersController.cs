using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TakeMeHome.API.TakeMeHome.Domain.Models;
using TakeMeHome.API.TakeMeHome.Domain.Services;
using TakeMeHome.API.TakeMeHome.Resources;
using TakeMeHome.API.TakeMeHome.Services;

namespace TakeMeHome.API.TakeMeHome.Controllers;


[ApiController]
[Route("/api/v1/orders/{userId}")]
public class UserOrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public UserOrdersController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<OrderResource>> GetAllByUserIdAsync(int userId)
    {
        var orders = await _orderService.ListByUserIdAsync(userId);
        var resources = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResource>>(orders);
        return resources;
    }
}