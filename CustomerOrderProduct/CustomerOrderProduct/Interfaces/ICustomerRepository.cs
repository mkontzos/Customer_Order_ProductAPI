using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Models;

namespace CustomerOrderProduct.Interfaces
{
   public interface ICustomerRepository : IBaseRepository<CustomerDto, Customer>
   {
   }
}
