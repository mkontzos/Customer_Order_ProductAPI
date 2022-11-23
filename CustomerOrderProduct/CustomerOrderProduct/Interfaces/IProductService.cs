using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Models;
using Generics.Messages;

namespace CustomerOrderProduct.Interfaces
{
	public interface IProductService
	{
		Task<GenericResponse<Product>> GetProductById(Guid id);
		Task<GenericResponse<ICollection<Product>>> GetProducts();
		Task<GenericResponse<ProductDto>> CreateProduct(ProductDto productDto);
		Task<GenericResponse<ProductDto>> UpdateProduct(ProductDto productDto);
		Task<GenericResponse<ProductDto>> DeleteProduct(Guid id);
	}
}
