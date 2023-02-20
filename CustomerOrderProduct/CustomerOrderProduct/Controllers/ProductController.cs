using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Interfaces;
using Generics.HelperClasses;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderProduct.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly IProductRepository _productService;

		public ProductController(IProductRepository productService)
		{
			_productService = productService;
		}

		[HttpGet]
		[Route("getAll")]
		public async Task<ActionResult> GetAll()
		{
			var result = await _productService.GetAll();

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
			var result = await _productService.GetById(id);

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
		public async Task<ActionResult> Create([FromBody] ProductDto productDto)
		{
			if (productDto == null)
			{
				return BadRequest();
			}

			var result = await _productService.Create(productDto);

			if (result.ErrorCode == ErrorCodes.Status500InternalServerError)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
			}

			return Ok(result);
		}

		[HttpPost]
		[Route("update")]
		public async Task<ActionResult> Update([FromBody] ProductDto productDto)
		{
			if (productDto == null)
			{
				return BadRequest();
			}

			var result = await _productService.Update(productDto);

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

			var result = await _productService.Delete(id);

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
