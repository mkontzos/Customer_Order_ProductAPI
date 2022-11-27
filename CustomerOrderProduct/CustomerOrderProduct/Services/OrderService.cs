using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Interfaces;
using CustomerOrderProduct.Models;
using Generics.HelperClasses;
using Generics.Messages;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderProduct.Services
{
	public class OrderService : IOrderService
	{
		private readonly CustomerOrderProductDbContext _customerOrderProductDbContext;

		public OrderService(CustomerOrderProductDbContext customerOrderProductDbContext)
		{
			_customerOrderProductDbContext = customerOrderProductDbContext;
		}

		public async Task<GenericResponse<OrderDto>> CreateOrder(OrderDto orderDto)
		{
			var response = new GenericResponse<OrderDto>();
			try
			{
				var order = new Order
				{
					Id = Guid.NewGuid(),
					CreatedDate = DateTime.Now,
					CustomerId = orderDto.CustomerId,
					Products = orderDto.Products,
				};

				_customerOrderProductDbContext.Entry(order).State = EntityState.Added;
				await _customerOrderProductDbContext.SaveChangesAsync();

				var createdOrderDto = new OrderDto
				{
					Id = order.Id
				};

				response.Success = true;
				response.Message = "Successfully created new order record.";
				response.Data = createdOrderDto;

				//return response;
			}
			catch (Exception e)
			{
				// log error
				response.Success = false;
				response.ErrorCode = ErrorCodes.Status500InternalServerError;
				response.Message = e.Message;

				//return response;
			}

			return response;
		}

		public async Task<GenericResponse<OrderDto>> GetOrderById(Guid id)
		{
			var response = new GenericResponse<OrderDto>();

			try
			{
				var order = await _customerOrderProductDbContext.Orders
					.Where(o => o.Id == id)
					.SingleOrDefaultAsync();

				if (order != null)
				{
					var orderDto = new OrderDto 
					{
						Id = order.Id,
						CreatedDate = order.CreatedDate,
						CanceledDate = order.CanceledDate,
						DeliveredDate = order.DeliveredDate,
						Customer = order.Customer,
						Products = order.Products
					};

					response.Data = orderDto;
					response.Success = true;

					return response;
				}

				response.Success = false;
				response.ErrorCode = ErrorCodes.Status404NotFound;
				response.Message = "No record with given id found in the database";

				//return response;
			}
			catch (Exception e)
			{
				// log error
				response.Success = false;
				response.ErrorCode = ErrorCodes.Status500InternalServerError;
				response.Message = e.Message;

				//return response;
			}

			return response;
		}

		public async Task<GenericResponse<ICollection<Order>>> GetOrders()
		{
			var response = new GenericResponse<ICollection<Order>>();
			try
			{
				var orders = await _customerOrderProductDbContext.Orders
					.ToListAsync();

				if (orders.Any())
				{
					response.Data = orders;
					response.Success = true;

					return response;
				}

				response.Success = false;
				response.ErrorCode = ErrorCodes.Status404NotFound;
				response.Message = "No order records found in the database.";

				//return response;
			}
			catch (Exception e)
			{
				// log error

				response.Success = false;
				response.ErrorCode = ErrorCodes.Status500InternalServerError;
				response.Message = e.Message;

				//return response;
			}

			return response;
		}

		public async Task<GenericResponse<OrderDto>> UpdateOrder(OrderDto orderDto)
		{
			var response = new GenericResponse<OrderDto>();

			try
			{
				var orderInDb = await _customerOrderProductDbContext.Orders
					.Where(o => o.Id == orderDto.Id)
					.SingleOrDefaultAsync();

				if (orderInDb != null)
				{
					orderInDb.CanceledDate = orderDto.CanceledDate;
					orderInDb.DeliveredDate = orderDto.DeliveredDate;

					// order manipulation for add or remove items
					// possible solution is to add flag on product
					// as added or deleted. Second solution is to
					// check missing items in old list and add them
					// and vice versa for the new list and delete them.

					_customerOrderProductDbContext.Entry(orderDto).State = EntityState.Modified;
					await _customerOrderProductDbContext.SaveChangesAsync();

					var updatedOrderDto = new OrderDto
					{
						Id = orderInDb.Id
					};

					response.Success = true;
					response.Data = updatedOrderDto;

					return response;
				}

				response.Success = false;
				response.ErrorCode = ErrorCodes.Status404NotFound;
				response.Message = "No record found with given id in database.";

				//return response;
			}
			catch (Exception e)
			{
				// log error
				response.Success = false;
				response.ErrorCode = ErrorCodes.Status500InternalServerError;
				response.Message = e.Message;

				//return response;
			}

			return response;
		}

		public async Task<GenericResponse<OrderDto>> DeleteOrder(Guid id)
		{
			var response = new GenericResponse<OrderDto>();

			try
			{
				var order = await _customerOrderProductDbContext.Orders
					.Where(o => o.Id == id)
					.SingleOrDefaultAsync();

				if (order != null)
				{
					var deletedOrderDto = new OrderDto
					{
						Id = id
					};

					response.Success = true;
					response.Data = deletedOrderDto;

					return response;
				}

				response.Success = false;
				response.ErrorCode = ErrorCodes.Status404NotFound;
				response.Message = "No record with give id found";

				//return response;
			}
			catch (Exception e)
			{
				// log error
				response.Success = false;
				response.ErrorCode = ErrorCodes.Status500InternalServerError;
				response.Message = e.Message;

				//return response;
			}

			return response;
		}
	}
}
