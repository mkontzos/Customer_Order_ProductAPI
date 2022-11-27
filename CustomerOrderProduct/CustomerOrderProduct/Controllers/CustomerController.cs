using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Interfaces;
using CustomerOrderProduct.Models;
using CustomerOrderProduct.Services;
using Generics.HelperClasses;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderProduct.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerService _customerService;

		public CustomerController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		[HttpGet]
		[Route("getAll")]
		public async Task<ActionResult> GetAll()
		{
			var result = await _customerService.GetCustomers();

			if (result.ErrorCode == ErrorCodes.Status404NotFound)
			{
				return NotFound(result);
			}
			else if (result.ErrorCode == ErrorCodes.Status500InternalServerError)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
			}

			return Ok(result);
		}

		[HttpGet]
		[Route("get/{id}")]
		public async Task<ActionResult> GetById(Guid id)
		{
			var result = await _customerService.GetCustomerById(id);

			if (result.ErrorCode == ErrorCodes.Status404NotFound)
			{
				return NotFound(result);
			}
			else if (result.ErrorCode == ErrorCodes.Status500InternalServerError)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
			}

			return Ok(result);
		}

		[HttpPost]
		[Route("add")]
		public async Task<ActionResult> Create([FromBody] CustomerDto customerDto)
		{
			if (customerDto == null)
			{
				return BadRequest();
			}

			var result = await _customerService.CreateCustomer(customerDto);

			if (result.ErrorCode == ErrorCodes.Status500InternalServerError)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
			}

			return Ok(result);
		}

		[HttpPost]
		[Route("update")]
		public async Task<ActionResult> Update([FromBody] CustomerDto customerDto)
		{
			if (customerDto == null)
			{
				return BadRequest();
			}

			var result = await _customerService.UpdateCustomer(customerDto);

			if (result.ErrorCode == ErrorCodes.Status404NotFound)
			{
				return NotFound(result);
			}
			else if (result.ErrorCode == ErrorCodes.Status500InternalServerError)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
			}

			return Ok(result);
		}

		[HttpDelete]
		[Route("delete/{id}")]
		public async Task<ActionResult> Delete(Guid id)
		{
			if (id == Guid.Empty)
			{
				return BadRequest();
			}

			var result = await _customerService.DeleteCustomer(id);

			if (result.ErrorCode == ErrorCodes.Status404NotFound)
			{
				return NotFound(result);
			}
			else if (result.ErrorCode == ErrorCodes.Status500InternalServerError)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
			}

			return Ok(result);
		}
	}
}
