using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
