using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace TranspolarProject.Areas.Customer.Controllers
{
	[Area("Customer")]
	[Route("Customer/Dashboard")]
	[Authorize(Roles = "Admin,Customer")]

	public class DashboardController : Controller
	{
		[Route("Index")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
