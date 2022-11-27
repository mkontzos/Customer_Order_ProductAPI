using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Models;
using Generics.Messages;

namespace CustomerOrderProduct.Interfaces
{
	public interface IOrderService
	{
		Task<GenericResponse<OrderDto>> GetOrderById(Guid id);
		Task<GenericResponse<ICollection<Order>>> GetOrders();
		Task<GenericResponse<OrderDto>> CreateOrder(OrderDto orderDto);
		Task<GenericResponse<OrderDto>> UpdateOrder(OrderDto orderDto);
		Task<GenericResponse<OrderDto>> DeleteOrder(Guid id);
	}
}
