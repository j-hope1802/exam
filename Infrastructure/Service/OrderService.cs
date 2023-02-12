using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Service;
public class OrderService : IOrderService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;


    public OrderService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }
    
    public decimal InstallementAmount( Category productcatgory, decimal ProductPrice, Installement installements)
    {
 
        decimal productamount = 0;
        if (productcatgory == Category.Smartphone)
        {
             if ((int)installements == 12)
            {
                productamount=  ((100 + 3) * ProductPrice) / 100;
            }
            else if ((int)installements == 18)
            {
                productamount =  ((100 + 6) * ProductPrice) / 100;
            }
            else if ((int)installements == 24)
            {
                productamount =  ((100 + 9) * ProductPrice) / 100;
            }
            else {productamount = ProductPrice; }
        }
        else if (productcatgory == Category.Computer)
            if ((installements == Installement.Three|| installements == Installement.Six || installements == Installement.Nine || installements == Installement.Twelve))
            {  }
            else if (installements == Installement.Eighteen)
            { productamount =  ((100 + 4) * ProductPrice) / 100; }
            else if (installements == Installement.TwentyFour)
            { productamount =  ((100 + 8) * ProductPrice) / 100; }
            else {  productamount = ProductPrice; }

        else if (productcatgory == Category.Television)
        {
            if (installements == Installement.Three || installements == Installement.Six|| installements == Installement.Nine || installements == Installement.Twelve || installements == Installement.Eighteen)
            {  productamount = ProductPrice; }
            else if (installements == Installement.TwentyFour)
            { productamount =  (((100 + 4)) * ProductPrice) / 100; }

        }
      
       ;
           return productamount;    
}
    public async Task<Response<List<OrderDto>>> GetOrder()
    {
        try
        {
            var response = await _context.Orders.ToListAsync();
            var mapped = _mapper.Map<List<OrderDto>>(response);
            return new Response<List<OrderDto>>(mapped);
        }
        catch (System.Exception ex)
        {
            return new Response<List<OrderDto>>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }

    }
    public async Task<Response<OrderDto>> GetOrderById(int id)
    {
        try
        {
            var response = await _context.Orders.FindAsync(id);
            var mapped = _mapper.Map<OrderDto>(response);
            return new Response<OrderDto>(mapped);
        }
        catch (System.Exception ex)
        {
            return new Response<OrderDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
    public async Task<Response<OrderDto>> AddOrder(AddOrder order)
    {
        try
        {
            var mapped = _mapper.Map<Order>(order);
            await _context.Orders.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<OrderDto>(order);
        }
        catch (System.Exception ex)
        {
            return new Response<OrderDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
                                                    
    public async Task<Response<OrderDto>> UpdateOrder(AddOrder order)
    {

        try
        {
              var result = await _context.Orders.FindAsync(order.Id);
          var mapped = _mapper.Map<AddOrder>(result);
            return new Response<OrderDto>(mapped);
        }
        catch (System.Exception ex)
        {
            return new Response<OrderDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
        
    }
    public async Task<Response<string>> DeleteOrder(int id)
    {
        var find = await _context.Orders.FindAsync(id);
        if(find==null) return new Response<string>(HttpStatusCode.NotFound,new List<string>{"Not found"});
        _context.Orders.Remove(find);
        _context.SaveChangesAsync();
        return new Response<string>("Sucessfully");
    }

}