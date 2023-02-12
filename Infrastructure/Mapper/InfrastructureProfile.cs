using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
namespace Infrastructure.MapperProfiles;

public class InfrastructureProfile : Profile
{
    public InfrastructureProfile()
    {
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<Order, AddOrder>().ReverseMap();
    }
}
