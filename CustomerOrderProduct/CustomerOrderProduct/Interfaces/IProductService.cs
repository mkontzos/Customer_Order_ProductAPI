using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Models;

namespace CustomerOrderProduct.Interfaces
{
	public interface IProductService
	{
		Task<Product> GetProductById(Guid id);
		Task<ICollection<Product>> GetProducts();
		Task<ProductDto> CreateProduct(ProductDto productDto);
		Task<ProductDto> UpdateProduct(ProductDto productDto);
		Task<ProductDto> DeleteProduct(Guid id);
	}
}
