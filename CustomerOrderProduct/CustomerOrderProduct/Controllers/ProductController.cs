using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Interfaces;
using CustomerOrderProduct.Models;
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

			if (result.Count > 0)
			{
				return Ok(result);
			}

			return NotFound();
		}

		[HttpGet]
		[Route("get/{id}")]
		public async Task<ActionResult> GetById(Guid id)
		{
			if (id != Guid.Empty)
			{
				var result = await _productService.GetProductById(id);

				if (result != null)
				{
					return Ok(result);
				}

				return NotFound();
			}
			
			return BadRequest();
		}

		[HttpPost]
		[Route("add")]
		public async Task<ActionResult> Create([FromBody] ProductDto productDto)
		{
			if (productDto != null)
			{
				var result = await _productService.CreateProduct(productDto);

				if (result != null)
				{
					return Ok(result);
				}

				return BadRequest();
			}
			return BadRequest() ;
		}

		[HttpPost]
		[Route("update")]
		public async Task<ActionResult> Update([FromBody] ProductDto productDto)
		{
			if (productDto != null)
			{
				var result = await _productService.UpdateProduct(productDto);

				if (result != null)
				{
					return Ok(result);
				}

				return NotFound();
			}
			return BadRequest();
		}

		[HttpDelete]
		[Route("delete/{id}")]
		public async Task<ActionResult> Delete(Guid id)
		{
			if (id != Guid.Empty)
			{
				var result = await _productService.DeleteProduct(id);

				if (result != null)
				{
					return Ok(result);
				}

				return NotFound();
			}

			return BadRequest();
		}
	}
}
