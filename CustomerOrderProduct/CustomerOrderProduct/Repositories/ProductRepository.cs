using AutoMapper;
using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Interfaces;
using CustomerOrderProduct.Models;

namespace CustomerOrderProduct.Services
{
   public class ProductRepository : BaseRepository<ProductDto, Product>, IProductRepository
   {
      private readonly CustomerOrderProductDbContext _customerOrderProductDbContext;

      public ProductRepository(CustomerOrderProductDbContext customerOrderProductDbContext,
         IMapper mapper)
         : base(customerOrderProductDbContext, mapper)
      {
         _customerOrderProductDbContext = customerOrderProductDbContext;
      }

      //public async Task<GenericResponse<ProductDto>> CreateProduct(ProductDto productDto)
      //{
      //	var response = new GenericResponse<ProductDto>();

      //	try
      //	{
      //		var product = new Product
      //		{
      //			Id = Guid.NewGuid(),
      //			Title = productDto.Title,
      //			Manufacturer = productDto.Manufacturer,
      //			ProductionDate = productDto.ProductionDate,
      //			ReturnDate = productDto.ReturnDate
      //		};

      //		_customerOrderProductDbContext.Entry(product).State = EntityState.Added;
      //		await _customerOrderProductDbContext.SaveChangesAsync();

      //		var productCreatedDto = new ProductDto
      //		{
      //			Id = product.Id
      //		};

      //		response.Success = true;
      //		response.Data = productCreatedDto;
      //		response.Message = "Successfully created record.";

      //		return response;
      //	}
      //	catch (Exception e)
      //	{
      //		// log error
      //		response.Success = false;
      //		response.ErrorCode = ErrorCodes.Status500InternalServerError;
      //		response.Message = e.Message;

      //		return response;
      //	}
      //}

      //public async Task<GenericResponse<Product>> GetProductById(Guid id)
      //{
      //	var response = new GenericResponse<Product>();

      //	try
      //	{
      //		var product = await _customerOrderProductDbContext.Product
      //			.Where(p => p.Id == id)
      //			.SingleOrDefaultAsync();

      //		if (product != null)
      //		{
      //			response.Success = true;
      //			response.Data = product;
      //			response.Message = "Successfully retrieved record.";

      //			return response;
      //		}

      //		response.Success = false;
      //		response.ErrorCode = ErrorCodes.Status404NotFound;
      //		response.Message = "No record found with given id.";

      //		return response;
      //	}
      //	catch (Exception e)
      //	{
      //		// log error
      //		response.Success = false;
      //		response.ErrorCode = ErrorCodes.Status500InternalServerError;
      //		response.Message = e.Message;

      //		return response;
      //	}
      //}

      //public async Task<GenericResponse<ICollection<Product>>> GetProducts()
      //{
      //	var response = new GenericResponse<ICollection<Product>>();

      //	try
      //	{
      //		var products = await _customerOrderProductDbContext.Product
      //			.ToListAsync();

      //		if (products.Count > 0)
      //		{
      //			response.Success = true;
      //			response.Data = products;
      //			response.Message = "Successfully retrieved records.";

      //			return response;
      //		}

      //		response.Success = false;
      //		response.ErrorCode = ErrorCodes.Status404NotFound;
      //		response.Message = "No records found in database.";

      //		return response;
      //	}
      //	catch (Exception e)
      //	{
      //		// log error
      //		response.Success = false;
      //		response.ErrorCode = ErrorCodes.Status500InternalServerError;
      //		response.Message = e.Message;

      //		return response;
      //	}
      //}

      //public async Task<GenericResponse<ProductDto>> UpdateProduct(ProductDto productDto)
      //{
      //	var response = new GenericResponse<ProductDto>();

      //	try
      //	{
      //		var productInDb = await _customerOrderProductDbContext.Product
      //			.Where(p => p.Id == productDto.Id)
      //			.SingleOrDefaultAsync();

      //		if (productInDb != null)
      //		{
      //			productInDb.Title = productDto.Title;
      //			productInDb.Manufacturer = productDto.Manufacturer;
      //			productInDb.ReturnDate = productDto.ReturnDate;

      //			if (productInDb.Orders != null && productInDb.Orders.Count > 0)
      //			{
      //				if (productDto.Orders != null && productDto.Orders.Count > 0)
      //				{
      //					foreach (var order in productDto.Orders)
      //					{
      //						var existingOrder = productInDb.Orders.Any(p => p.Id == order.Id);

      //						if (existingOrder == false)
      //						{
      //							productInDb.Orders.Add(order);
      //						}
      //					}
      //				}
      //			}
      //			else
      //			{
      //				productDto.Orders = productDto.Orders;
      //			}

      //			_customerOrderProductDbContext.Entry(productInDb).State = EntityState.Modified;
      //			await _customerOrderProductDbContext.SaveChangesAsync();

      //			var updatedProductDto = new ProductDto
      //			{
      //				Id = productInDb.Id,
      //				Title = productInDb.Title,
      //				Manufacturer = productInDb.Manufacturer,
      //				ProductionDate = productInDb.ProductionDate,
      //				ReturnDate = productInDb.ReturnDate,
      //				Orders = productInDb.Orders
      //			};

      //			response.Success = true;
      //			response.Data = updatedProductDto;
      //			response.Message = "Successfully updated record.";

      //			return response;
      //		}

      //		response.Success = false;
      //		response.ErrorCode = ErrorCodes.Status404NotFound;
      //		response.Message = "No record found with given id.";

      //		return response;
      //	}
      //	catch (Exception e)
      //	{
      //		// log error
      //		response.Success = false;
      //		response.ErrorCode = ErrorCodes.Status500InternalServerError;
      //		response.Message = e.Message;

      //		return response;
      //	}
      //}

      //public async Task<GenericResponse<ProductDto>> DeleteProduct(Guid id)
      //{
      //	var response = new GenericResponse<ProductDto>();

      //	try
      //	{
      //		var productInBd = await _customerOrderProductDbContext.Product
      //			.Where(p => p.Id == id)
      //			.SingleOrDefaultAsync();

      //		if (productInBd != null)
      //		{
      //			var productDto = new ProductDto
      //			{
      //				Id = productInBd.Id
      //			};

      //			_customerOrderProductDbContext.Entry(productInBd).State = EntityState.Deleted;
      //			await _customerOrderProductDbContext.SaveChangesAsync();

      //			response.Success = true;
      //			response.Data = productDto;
      //			response.Message = "Successfully deleted record.";

      //			return response;
      //		}

      //		response.Success = false;
      //		response.ErrorCode = ErrorCodes.Status404NotFound;
      //		response.Message = "No record found with given id.";

      //		return response;
      //	}
      //	catch (Exception e)
      //	{
      //		// log error
      //		response.Success = true;
      //		response.ErrorCode = ErrorCodes.Status500InternalServerError;
      //		response.Message = e.Message;

      //		return response;
      //	}
      //}
   }
}
