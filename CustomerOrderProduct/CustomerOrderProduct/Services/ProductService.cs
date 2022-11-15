using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Interfaces;
using CustomerOrderProduct.Models;

namespace CustomerOrderProduct.Services
{
	public class ProductService : IProductService
	{
		public Task<ProductDto> CreateProduct(ProductDto productDto)
		{
			throw new NotImplementedException();
		}

		public Task<Product> GetProductById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<ICollection<Product>> GetProducts()
		{
			throw new NotImplementedException();
		}

		public Task<Product> UpdateProduct(ProductDto productDto)
		{
			throw new NotImplementedException();
		}

		public Task DeleteProduct(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
