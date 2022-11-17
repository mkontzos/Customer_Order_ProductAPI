using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Models;
using Helpers.Messages;

namespace CustomerOrderProduct.Interfaces
{
	public interface IOrderService
	{
		Task<GenericResponse<OrderDto>> GetOrderById(Guid id);
		Task<GenericResponse<List<Order>>> GetOrders();
		Task<GenericResponse<OrderDto>> CreateOrder(OrderDto orderDto);
		Task<GenericResponse<OrderDto>> UpdateOrder(OrderDto orderDto);
		Task<GenericResponse<OrderDto>> DeleteOrder(Guid id);
	}
}
