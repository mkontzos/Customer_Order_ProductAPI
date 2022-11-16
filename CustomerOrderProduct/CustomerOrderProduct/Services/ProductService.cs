using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Interfaces;
using CustomerOrderProduct.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderProduct.Services
{
	public class ProductService : IProductService
	{
		private readonly CustomerOrderProductDbContext _customerOrderProductDbContext;

		public ProductService(CustomerOrderProductDbContext customerOrderProductDbContext)
		{
			_customerOrderProductDbContext = customerOrderProductDbContext;
		}

		public async Task<ProductDto> CreateProduct(ProductDto productDto)
		{
			try
			{
				var product = new Product
				{
					Id = Guid.NewGuid(),
					Title = productDto.Title,
					Manufacturer = productDto.Manufacturer,
					ProductionDate = productDto.ProductionDate,
					ReturnDate = productDto.ReturnDate
				};

				_customerOrderProductDbContext.Entry(product).State = EntityState.Added;
				await _customerOrderProductDbContext.SaveChangesAsync();

				var productCreatedDto = new ProductDto
				{
					Id = product.Id
				};

				return productCreatedDto;
			}
			catch (Exception e)
			{
				// log error
				return null;
			}
		}

		public async Task<Product> GetProductById(Guid id)
		{
			try
			{
				var product = await _customerOrderProductDbContext.Product
					.Where(p => p.Id == id)
					.SingleOrDefaultAsync();

				return product;
			}
			catch (Exception e)
			{
				// log error
				return null;
			}
		}

		public async Task<ICollection<Product>> GetProducts()
		{
			try
			{
				var products = await _customerOrderProductDbContext.Product
					.ToListAsync();

				return products;
			}
			catch (Exception e)
			{
				// log error
				return new List<Product>();
			}
		}

		public async Task<ProductDto> UpdateProduct(ProductDto productDto)
		{
			try
			{
				var productInDb = await _customerOrderProductDbContext.Product
					.Where(p => p.Id == productDto.Id)
					.SingleOrDefaultAsync();

				if (productInDb != null)
				{
					productInDb.Title = productDto.Title;
					productInDb.Manufacturer = productDto.Manufacturer;
					productInDb.ReturnDate = productDto.ReturnDate;

					if (productInDb.Orders != null && productInDb.Orders.Count > 0)
					{
						if (productDto.Orders != null && productDto.Orders.Count > 0)
						{
							foreach (var order in productDto.Orders)
							{
								var existingOrder = productInDb.Orders.Where(p => p.Id == order.Id);

								if (existingOrder == null)
								{
									productInDb.Orders.Add(order);
								}
							}
						}
					}
					else
					{
						productDto.Orders = productDto.Orders;
					}

					_customerOrderProductDbContext.Entry(productInDb).State = EntityState.Modified;
					await _customerOrderProductDbContext.SaveChangesAsync();

					var updatedProductDto = new ProductDto
					{
						Id = productInDb.Id,
						Title = productInDb.Title,
						Manufacturer = productInDb.Manufacturer,
						ProductionDate = productInDb.ProductionDate,
						ReturnDate = productInDb.ReturnDate,
						Orders = productInDb.Orders
					};

					return updatedProductDto;
				}

				return null;
			}
			catch (Exception e)
			{
				// log error
				return null;
			}
		}

		public async Task<ProductDto> DeleteProduct(Guid id)
		{
			try
			{
				var productInBd = await _customerOrderProductDbContext.Product
					.Where(p => p.Id == id)
					.SingleOrDefaultAsync();

				if (productInBd != null)
				{
					var productDto = new ProductDto
					{
						Id = productInBd.Id
					};

					_customerOrderProductDbContext.Entry(productInBd).State = EntityState.Deleted;
					await _customerOrderProductDbContext.SaveChangesAsync();

					return productDto;
				}

				return null;
			}
			catch (Exception e)
			{
				// log error
				return null;
			}
		}
	}
}
