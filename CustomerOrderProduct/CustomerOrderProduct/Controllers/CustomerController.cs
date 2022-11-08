using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderProduct.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CustomerController : ControllerBase
	{
		[HttpGet]
		[Route("getAll")]
		public ActionResult GetAll(Guid id)
		{
			return null;
		}

		[HttpGet]
		[Route("get/{id}")]
		public ActionResult GetById(Guid id)
		{
			return null;
		}

		[HttpPost]
		[Route("add")]
		public ActionResult Create()
		{
			return null;
		}

		[HttpPost]
		[Route("update")]
		public ActionResult Update()
		{
			return null;
		}

		[HttpDelete]
		[Route("delete/{id}")]
		public ActionResult Delete(Guid id)
		{
			return null;
		}
	}
}
