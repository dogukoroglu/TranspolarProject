using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.Controllers
{
	public class ErrorPageController : Controller
	{
		public IActionResult Error401()
		{
			return View();
		}

		public IActionResult Error404()
		{
			return View();
		}
	}
}
