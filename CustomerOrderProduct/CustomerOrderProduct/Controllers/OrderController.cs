using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderProduct.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrderController : ControllerBase
	{
		public ActionResult Index()
		{
			return null;
		}
	}
}
