using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
