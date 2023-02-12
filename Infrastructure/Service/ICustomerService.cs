using Domain.Dtos;
using Domain.Wrapper;

namespace Infrastructure.Services;

public interface ICustomerService
{
    Task<Response<List<CustomerDto>>> GetCustomers();
    Task<Response<CustomerDto>> GetCustomerById(int id);
    Task<Response<CustomerDto>> AddCustomer(AddCustomer customer);
    Task<Response<CustomerDto>> UpdateCustomer(AddCustomer customer);
    Task<Response<string>> DeleteCustomer(int id);
    
}