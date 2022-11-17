using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Interfaces;
using CustomerOrderProduct.Models;
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
			throw new NotImplementedException();
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
				response.ErrorCode = "404";
				response.Message = "No record with given id found in the database";

				return response;
			}
			catch (Exception e)
			{
				// log error
				response.Success = false;
				response.ErrorCode = "500";
				response.Message = e.Message;

				return response;
			}
		}

		public async Task<GenericResponse<List<Order>>> GetOrders()
		{
			var response = new GenericResponse<List<Order>>();
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
				response.ErrorCode = "404";
				response.Message = "No order records found in the database.";

				return response;
			}
			catch (Exception e)
			{
				// log error

				response.Success = false;
				response.ErrorCode = "500";
				response.Message = e.Message;

				return response;
			}
			
		}

		public async Task<GenericResponse<OrderDto>> UpdateOrder(OrderDto orderDto)
		{
			throw new NotImplementedException();
		}

		public async Task<GenericResponse<OrderDto>> DeleteOrder(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
