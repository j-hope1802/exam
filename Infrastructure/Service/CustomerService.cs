using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Service;
public class CustomerService : ICustomerService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CustomerService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    public async Task<Response<List<CustomerDto>>> GetCustomers()
    {
        try
        {
            var response = await _context.Customers.ToListAsync();
            var mapped = _mapper.Map<List<CustomerDto>>(response);
            return new Response<List<CustomerDto>>(mapped);
        }
        catch (System.Exception ex)
        {
            return new Response<List<CustomerDto>>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }

    }
    public async Task<Response<CustomerDto>> GetCustomerById(int id)
    {
        try
        {
            var response = await _context.Customers.FindAsync(id);
            var mapped = _mapper.Map<CustomerDto>(response);
            return new Response<CustomerDto>(mapped);
        }
        catch (System.Exception ex)
        {
            return new Response<CustomerDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
    public async Task<Response<CustomerDto>> AddCustomer(AddCustomer customer)
    {
        try
        {
            var mapped = _mapper.Map<Customer>(customer);
            await _context.Customers.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<CustomerDto>(customer);
        }
        catch (System.Exception ex)
        {
            return new Response<CustomerDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<CustomerDto>> UpdateCustomer(AddCustomer customer)
    {
          var result = await _context.Customers.FindAsync(customer.Id);
          var mapped = _mapper.Map<AddCustomer>(result);
            return new Response<CustomerDto>(mapped);
    }

    public async Task<Response<string>> DeleteCustomer(int id)
    {
        var find = await _context.Customers.FindAsync(id);
        if(find==null) return new Response<string>(HttpStatusCode.NotFound,new List<string>{"Not found"});
        _context.Customers.Remove(find);
        _context.SaveChangesAsync();
        return new Response<string>("Sucessfully");
    }

}