using AutoMapper;
using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Interfaces;
using CustomerOrderProduct.Models;

namespace CustomerOrderProduct.Services
{
   public class OrderRepository : BaseRepository<OrderDto, Order>, IOrderRepository
   {
      private readonly CustomerOrderProductDbContext _customerOrderProductDbContext;

      public OrderRepository(CustomerOrderProductDbContext customerOrderProductDbContext, IMapper mapper)
         : base(customerOrderProductDbContext, mapper)
      {
         _customerOrderProductDbContext = customerOrderProductDbContext;
      }

   }
}
