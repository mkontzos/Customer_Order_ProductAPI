using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Interfaces;
using CustomerOrderProduct.Models;
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
			try
			{
				var result = await _customerService.GetCustomers();

				if (result.Count > 0)
				{
					return Ok(result);
				}

				return NotFound();
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

		[HttpGet]
		[Route("get")]
		public async Task<ActionResult> GetById([FromQuery] Guid id)
		{
			try
			{
				var result = await _customerService.GetCustomerById(id);

				if (result != null)
				{
					return Ok(result);
				}

				return NotFound();
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

		[HttpPost]
		[Route("add")]
		public async Task<ActionResult> Create([FromBody] CustomerDto customerDto)
		{
			if (customerDto != null)
			{
				try
				{
					var result = await _customerService.CreateCustomer(customerDto);

					if (result != null)
					{
						return Ok(result);
					}

					return BadRequest();
				}
				catch (Exception e)
				{
					return BadRequest(e);
				}
			}

			return BadRequest();
		}

		[HttpPost]
		[Route("update")]
		public async Task<ActionResult> Update([FromBody] CustomerDto customerDto)
		{
			if (customerDto != null)
			{
				try
				{
					var result = await _customerService.UpdateCustomer(customerDto);

					if (result != null)
					{
						return Ok(result);
					}

					return NotFound();
				}
				catch (Exception e)
				{
					return BadRequest(e);
				}
			}

			return BadRequest();
		}

		[HttpDelete]
		[Route("delete")]
		public async Task<ActionResult> Delete([FromQuery] Guid id)
		{
			if (id != Guid.Empty)
			{
				try
				{
					var result = await _customerService.DeleteCustomer(id);

					if (result != null)
					{
						return Ok(result);
					}

					return NotFound();
				}
				catch (Exception e)
				{
					return BadRequest(e);
				}
			}

			return BadRequest();
		}
	}
}
