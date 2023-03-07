using AutoMapper;
using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Interfaces;
using CustomerOrderProduct.Models;

namespace CustomerOrderProduct.Services
{
   public class CustomerRepository : BaseRepository<CustomerDto, Customer>, ICustomerRepository
   {
      private readonly CustomerOrderProductDbContext _customerOrderProductDbContext;

      public CustomerRepository(CustomerOrderProductDbContext customerOrderProductDbContext, IMapper mapper)
         : base(customerOrderProductDbContext, mapper)
      {
         _customerOrderProductDbContext = customerOrderProductDbContext;
      }

   }
}
