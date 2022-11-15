using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Models;

namespace CustomerOrderProduct.Interfaces
{
	public interface IProductService
	{
		Task<Product> GetProductById(Guid id);
		Task<ICollection<Product>> GetProducts();
		Task<ProductDto> CreateProduct(ProductDto productDto);
		Task<Product> UpdateProduct(ProductDto productDto);
		Task DeleteProduct(Guid id);
	}
}
