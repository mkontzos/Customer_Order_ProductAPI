using CustomerOrderProduct.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderProduct.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet]
		[Route("getAll")]
		public async Task<ActionResult> GetAll()
		{
			var result = await _orderService.GetOrders();

			if (result.ErrorCode == "404")
			{
				return NotFound(result);
			}
			else if(result.ErrorCode == "500")
			{
				return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
			}

			return Ok(result);
		}

		[HttpGet]
		[Route("get/{id}")]
		public async Task<ActionResult> GetById(Guid id)
		{
			var result = await _orderService.GetOrderById(id);

			if (result.ErrorCode == "404")
			{
				return NotFound(result);
			}
			else if (result.ErrorCode == "500")
			{
				return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
			}

			return Ok(result);
		}

		[HttpPost]
		[Route("add")]
		public async Task<ActionResult> Create()
		{
			return null;
		}

		[HttpPost]
		[Route("update")]
		public async Task<ActionResult> Update()
		{
			return null;
		}

		[HttpDelete]
		[Route("delete/{id}")]
		public async Task<ActionResult> Delete(Guid id)
		{
			return null;
		}
	}
}
