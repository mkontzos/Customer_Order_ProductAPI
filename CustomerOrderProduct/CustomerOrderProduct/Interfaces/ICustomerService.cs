using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Models;
using Generics.Messages;

namespace CustomerOrderProduct.Interfaces
{
	public interface ICustomerService
	{
		Task<GenericResponse<Customer>> GetCustomerById(Guid id);
		Task<GenericResponse<ICollection<Customer>>> GetCustomers();
		Task<GenericResponse<CustomerDto>> CreateCustomer(CustomerDto customerDto);
		Task<GenericResponse<CustomerDto>> UpdateCustomer(CustomerDto customerDto);
		Task<GenericResponse<CustomerDto>> DeleteCustomer(Guid id);
	}
}
