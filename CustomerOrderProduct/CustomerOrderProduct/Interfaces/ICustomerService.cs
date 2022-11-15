using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Models;

namespace CustomerOrderProduct.Interfaces
{
	public interface ICustomerService
	{
		Task<Customer> GetCustomerById(Guid id);
		Task<ICollection<Customer>> GetCustomers();
		Task<CustomerDto> CreateCustomer(CustomerDto customerDto);
		Task<CustomerDto> UpdateCustomer(CustomerDto customerDto);
		Task<CustomerDto> DeleteCustomer(Guid id);
	}
}
