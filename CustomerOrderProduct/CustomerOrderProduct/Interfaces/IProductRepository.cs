using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Models;

namespace CustomerOrderProduct.Interfaces
{
   public interface IProductRepository : IBaseRepository<ProductDto, Product>
   {
   }
}
