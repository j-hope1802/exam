using System.Security.Principal;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("[controller]")]
public class CustomerController:ControllerBase
{
    private readonly ICustomerService _todoService;
    private readonly IWebHostEnvironment _environment;

    public CustomerController(ICustomerService todoService, IWebHostEnvironment environment)
    {
        _todoService = todoService;
        _environment = environment;
    }
 
    [HttpGet("GetCustomer")]
    public async Task<Response<List<CustomerDto>>> GetCustomer()
    {
        return await _todoService.GetCustomers();
    }
    [HttpGet("GetCustomerById")]
    public async Task<Response<CustomerDto>> GetCustomerById(int id)
    {
        return await _todoService.GetCustomerById(id);
    }

    [HttpPost("AddCustomer")]
    public async Task<Response<CustomerDto>> AddCustomer([FromForm]AddCustomer customer)
    {
        return await _todoService.AddCustomer(customer);
    }

    [HttpPut("UpdateCustomer")]
    public async Task<Response<CustomerDto>> UpdateCustomer([FromBody]AddCustomer customer)
    {
        return await _todoService.UpdateCustomer(customer);
    }
    

    [HttpDelete("DeleteCustomer")]
    public async Task<Response<string>> DeleteCustomer(int id)
    {
        return await _todoService.DeleteCustomer(id);
    }


}