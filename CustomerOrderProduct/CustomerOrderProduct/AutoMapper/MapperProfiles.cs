using AutoMapper;
using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Models;

namespace CustomerOrderProduct.AutoMapper;

public class MapperProfiles : Profile
{
   public MapperProfiles()
   {
      CreateMap<CustomerDto, Customer>();
      CreateMap<Customer, CustomerDto>();
      CreateMap<CustomerDto, Customer>();
      CreateMap<Customer, CustomerDto>();
      CreateMap<ProductDto, Product>();
      CreateMap<Product, ProductDto>();
   }
}
