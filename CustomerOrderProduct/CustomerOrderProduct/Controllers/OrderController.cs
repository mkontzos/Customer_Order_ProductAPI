using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderProduct.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrderController : ControllerBase
	{
		[HttpGet]
		[Route("getAll")]
		public async Task<ActionResult> GetAll()
		{
			return null;
		}

		[HttpGet]
		[Route("get/{id}")]
		public async Task<ActionResult> GetById(Guid id)
		{
			return null;
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
