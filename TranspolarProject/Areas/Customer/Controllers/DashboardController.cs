using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.Areas.Customer.Controllers
{
	[Area("Customer")]
	[Route("Customer/Dashboard")]
	public class DashboardController : Controller
	{
		[Route("Index")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
