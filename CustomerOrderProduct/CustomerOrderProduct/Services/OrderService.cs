using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Interfaces;
using CustomerOrderProduct.Models;

namespace CustomerOrderProduct.Services
{
	public class OrderService : IOrderService
	{
		public Task<OrderDto> CreateOrder(OrderDto orderDto)
		{
			throw new NotImplementedException();
		}

		public Task<Order> GetOrderById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<ICollection<Order>> GetOrders()
		{
			throw new NotImplementedException();
		}

		public Task<OrderDto> UpdateOrder(OrderDto orderDto)
		{
			throw new NotImplementedException();
		}

		public Task<OrderDto> DeleteOrder(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
