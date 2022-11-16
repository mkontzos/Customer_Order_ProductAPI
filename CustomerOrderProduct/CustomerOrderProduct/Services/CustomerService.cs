using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Interfaces;
using CustomerOrderProduct.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderProduct.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly CustomerOrderProductDbContext _customerOrderProductDbContext;

		public CustomerService(CustomerOrderProductDbContext customerOrderProductDbContext)
		{
			_customerOrderProductDbContext = customerOrderProductDbContext;
		}

		public async Task<CustomerDto> CreateCustomer(CustomerDto customerDto)
		{
			try
			{
				var customer = new Customer 
				{
					Id = Guid.NewGuid(),
					Address = customerDto.Address,
					Firstname = customerDto.Firstname,
					Lastname = customerDto.Lastname,
					Gender = customerDto.Gender,
					Email = customerDto.Email,
					BirthDate = customerDto.BirthDate,
					CreatedDate = customerDto.CreatedDate,
				};

				_customerOrderProductDbContext.Entry(customer).State = EntityState.Added;
				await _customerOrderProductDbContext.SaveChangesAsync();

				var createdCustomerDto = new CustomerDto
				{
					Id = customer.Id
				};

				return createdCustomerDto;
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public async Task<Customer> GetCustomerById(Guid id)
		{
			try
			{
				var customer = await _customerOrderProductDbContext.Customers
					.Where(c => c.Id == id)
					.SingleOrDefaultAsync();

				if (customer != null)
				{
					return customer;
				}

				return null;
			}
			catch (Exception e)
			{
				// log error
				return null;
			}
		}

		public async Task<ICollection<Customer>> GetCustomers()
		{
			try
			{
				var customers = await _customerOrderProductDbContext.Customers
				.ToListAsync();

				if (customers.Count > 0)
				{
					return customers;
				}

				return new List<Customer>();
			}
			catch (Exception e)
			{
				// log error
				return new List<Customer>();
			}
		}

		public async Task<CustomerDto> UpdateCustomer(CustomerDto customerDto)
		{
			try
			{
				var customerInDb = await _customerOrderProductDbContext.Customers
					.Where(c => c.Id == customerDto.Id)
					.SingleOrDefaultAsync();

				if (customerInDb != null)
				{

					customerInDb.Address = customerDto.Address;
					customerInDb.Firstname = customerDto.Firstname;
					customerInDb.Lastname = customerDto.Lastname;
					customerInDb.Gender = customerDto.Gender;
					customerInDb.Email = customerDto.Email;
					customerInDb.BirthDate = customerDto.BirthDate;
					customerInDb.UpdatedDate = customerDto.UpdatedDate;

					_customerOrderProductDbContext.Entry(customerInDb).State = EntityState.Modified;
					await _customerOrderProductDbContext.SaveChangesAsync();

					return customerDto;
				}

				return null;
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public async Task<CustomerDto> DeleteCustomer(Guid id)
		{
			try
			{
				var customerInDb = await _customerOrderProductDbContext.Customers
					.Where(c => c.Id == id)
					.SingleOrDefaultAsync();

				if (customerInDb != null)
				{
					var customerDto = new CustomerDto
					{
						Id = customerInDb.Id
					};

					_customerOrderProductDbContext.Entry(customerInDb).State = EntityState.Deleted;
					await _customerOrderProductDbContext.SaveChangesAsync();

					return customerDto;
				}

				return null;
			}
			catch (Exception e)
			{
				return null;
			}
		}
	}
}
