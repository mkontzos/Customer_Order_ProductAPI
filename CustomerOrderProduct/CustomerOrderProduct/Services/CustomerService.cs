using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Interfaces;
using CustomerOrderProduct.Models;

namespace CustomerOrderProduct.Services
{
	public class CustomerService : ICustomerService
	{
		public Task<CustomerDto> CreateCustomer(CustomerDto customerDto)
		{
			throw new NotImplementedException();
		}

		public Task DeleteCustomer(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<Customer> GetCustomerById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<ICollection<Customer>> GetCustomers()
		{
			throw new NotImplementedException();
		}

		public Task<Customer> UpdateCustomer(CustomerDto customerDto)
		{
			throw new NotImplementedException();
		}
	}
}
