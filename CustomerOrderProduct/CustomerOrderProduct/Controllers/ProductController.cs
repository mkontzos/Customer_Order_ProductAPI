﻿using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderProduct.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductController : ControllerBase
	{
		public ActionResult Index()
		{
			return null;
		}
	}
}
