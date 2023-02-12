using System.Security.Principal;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("[controller]")]
public class OrderController:ControllerBase
{
    private readonly IOrderService _todoService;
    private readonly IWebHostEnvironment _environment;

    public OrderController(IOrderService todoService, IWebHostEnvironment environment)
    {
        _todoService = todoService;
        _environment = environment;
    }
 [HttpPost]
    public decimal InstallementAmount(Category productcatgory, decimal ProductPrice, Installement installements )
    {
        return  _todoService.InstallementAmount( productcatgory,  ProductPrice,  installements);
    }
    [HttpGet("GetOrders")]
    public async Task<Response<List<OrderDto>>> GetOrders()
    {
        return await _todoService.GetOrder();
    }
    [HttpGet("GetOrderById")]
    public async Task<Response<OrderDto>> GetOrderById(int id)
    {
        return await _todoService.GetOrderById(id);
    }

    [HttpPut("UpdateOrder")]
    public async Task<Response<OrderDto>> UpdateOrder([FromBody]AddOrder order)
    {
        return await _todoService.UpdateOrder(order);
    }
    

    [HttpDelete("DeleteOrder")]
    public async Task<Response<string>> DeleteOrder(int id)
    {
        return await _todoService.DeleteOrder(id);
    }


}