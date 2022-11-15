using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Models;

namespace CustomerOrderProduct.Interfaces
{
	public interface IOrderService
	{
		Task<Order> GetOrderById(Guid id);
		Task<ICollection<Order>> GetOrders();
		Task<OrderDto> CreateOrder(OrderDto orderDto);
		Task<OrderDto> UpdateOrder(OrderDto orderDto);
		Task<OrderDto> DeleteOrder(Guid id);
	}
}
