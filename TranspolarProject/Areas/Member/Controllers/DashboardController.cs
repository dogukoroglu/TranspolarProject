using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace TranspolarProject.Areas.Member.Controllers
{
	[Area("Member")]
	[Authorize(Roles = "Admin")]

	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
