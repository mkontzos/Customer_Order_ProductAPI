using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Models;

namespace CustomerOrderProduct.Interfaces
{
   public interface IOrderRepository : IBaseRepository<OrderDto, Order>
   {
   }
}
