using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Interfaces;
using CustomerOrderProduct.Models;
using Generics.HelperClasses;
using Generics.Messages;
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

		public async Task<GenericResponse<CustomerDto>> CreateCustomer(CustomerDto customerDto)
		{
			var response = new GenericResponse<CustomerDto>();
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
					CreatedDate = DateTime.Now,
				};

				_customerOrderProductDbContext.Entry(customer).State = EntityState.Added;
				await _customerOrderProductDbContext.SaveChangesAsync();

				var createdCustomerDto = new CustomerDto
				{
					Id = customer.Id
				};

				response.Success = true;
				response.Data = createdCustomerDto;
				response.Message = "Successfully created record";

				return response;
			}
			catch (Exception e)
			{
				response.Success = false;
				response.ErrorCode = ErrorCodes.Status500InternalServerError;
				response.Message = e.Message;

				return response;
			}
		}

		public async Task<GenericResponse<Customer>> GetCustomerById(Guid id)
		{
			var response = new GenericResponse<Customer>();

			try
			{
				var customer = await _customerOrderProductDbContext.Customers
					.Where(c => c.Id == id)
					.SingleOrDefaultAsync();

				if (customer != null)
				{
					response.Success = true;
					response.Data = customer;
					response.Message = "Successfully retrieved record from database";

					return response;
				}

				response.Success = false;
				response.ErrorCode = ErrorCodes.Status404NotFound;
				response.Message = "No record found with given id";

				return response;
			}
			catch (Exception e)
			{
				// log error
				response.Success = false;
				response.ErrorCode = ErrorCodes.Status500InternalServerError;
				response.Message = e.Message;

				return response;
			}
		}

		public async Task<GenericResponse<ICollection<Customer>>> GetCustomers()
		{
			var response = new GenericResponse<ICollection<Customer>>();
			try
			{
				var customers = await _customerOrderProductDbContext.Customers
				.ToListAsync();

				if (customers.Count > 0)
				{
					response.Success = true;
					response.Data = customers;
					response.Message = "Successfully retrieved records.";

					return response;
				}

				response.Success = false;
				response.ErrorCode = ErrorCodes.Status404NotFound;
				response.Message = "No records found in database.";

				return response;
			}
			catch (Exception e)
			{
				// log error
				response.Success = false;
				response.ErrorCode= ErrorCodes.Status500InternalServerError;
				response.Message = e.Message;

				return response;
			}
		}

		public async Task<GenericResponse<CustomerDto>> UpdateCustomer(CustomerDto customerDto)
		{
			var response = new GenericResponse<CustomerDto>();

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
					customerInDb.UpdatedDate = DateTime.Now;

					// Pending handling for orders

					_customerOrderProductDbContext.Entry(customerInDb).State = EntityState.Modified;
					await _customerOrderProductDbContext.SaveChangesAsync();

					response.Success = true;
					response.Data = customerDto;
					response.Message = "Successfully updated record.";

					return response;
				}

				response.Success = false;
				response.ErrorCode = ErrorCodes.Status404NotFound;
				response.Message = "No record found with given id.";

				return response;
			}
			catch (Exception e)
			{
				response.Success = false;
				response.ErrorCode = ErrorCodes.Status500InternalServerError;
				response.Message = e.Message;

				return response;
			}
		}

		public async Task<GenericResponse<CustomerDto>> DeleteCustomer(Guid id)
		{
			var response = new GenericResponse<CustomerDto>();

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

					response.Success = true;
					response.Data = customerDto;
					response.Message = "Successfully deleted record.";

					return response;
				}

				response.Success = false;
				response.ErrorCode = ErrorCodes.Status404NotFound;
				response.Message = "No record found with given id.";

				return response;
			}
			catch (Exception e)
			{
				response.Success = false;
				response.ErrorCode = ErrorCodes.Status500InternalServerError;
				response.Message = e.Message;

				return response;
			}
		}
	}
}
