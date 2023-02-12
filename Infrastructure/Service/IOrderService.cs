using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;

namespace Infrastructure.Services;

public interface IOrderService
{ decimal InstallementAmount(Category productcatgory, decimal ProductPrice, Installement installements);
    Task<Response<List<OrderDto>>> GetOrder();
    Task<Response<OrderDto>> GetOrderById(int id);

    Task<Response<OrderDto>> UpdateOrder(AddOrder order);
    Task<Response<string>> DeleteOrder(int id);
    
}