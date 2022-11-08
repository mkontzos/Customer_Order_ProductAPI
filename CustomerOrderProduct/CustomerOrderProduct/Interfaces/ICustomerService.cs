using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Models;

namespace CustomerOrderProduct.Interfaces
{
	public interface ICustomerService
	{
		Task<Customer> GetCustomerById(Guid id);
		Task<ICollection<Customer>> GetCustomers();
		Task<CustomerDto> CreateCustomer(CustomerDto customerDto);
		Task<Customer> UpdateCustomer(CustomerDto customerDto);
		Task DeleteCustomer(Guid id);
	}
}
