using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Interfaces;
using Generics.HelperClasses;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderProduct.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrderController : ControllerBase
	{
		private readonly IOrderRepository _orderService;

		public OrderController(IOrderRepository orderService)
		{
			_orderService = orderService;
		}

		[HttpGet]
		[Route("getAll")]
		public async Task<ActionResult> GetAll()
		{
			var result = await _orderService.GetAll();

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
			var result = await _orderService.GetById(id);

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
		public async Task<ActionResult> Create([FromBody] OrderDto orderDto)
		{
			if (orderDto == null)
			{
				return BadRequest();
			}

			var result = await _orderService.Create(orderDto);

			if (result.ErrorCode == ErrorCodes.Status500InternalServerError)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
			}

			return Ok(result);
		}

		[HttpPost]
		[Route("update")]
		public async Task<ActionResult> Update([FromBody] OrderDto orderDto)
		{
			if (orderDto == null)
			{
				return BadRequest();
			}

			var result = await _orderService.Update(orderDto);

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

			var result = await _orderService.Delete(id);

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
