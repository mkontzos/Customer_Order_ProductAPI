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
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		[Route("getAll")]
		public async Task<ActionResult> GetAll()
		{
			var result = await _productService.GetProducts();

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
			var result = await _productService.GetProductById(id);

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

			var result = await _productService.CreateProduct(productDto);

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

			var result = await _productService.UpdateProduct(productDto);

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

			var result = await _productService.DeleteProduct(id);

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
