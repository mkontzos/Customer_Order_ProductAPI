using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderProduct.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CustomerController : ControllerBase
	{
		public ActionResult Index()
		{
			return null;
		}
	}
}
