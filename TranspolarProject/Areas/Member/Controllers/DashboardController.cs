using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;

namespace TranspolarProject.Areas.Member.Controllers
{
	[Area("Member")]
	[Authorize(Roles = "Admin")]

	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			Context c = new Context();
			ViewBag.staffCount = c.Staffs.Count();
			ViewBag.requestCount = c.ServiceRequests.Count();
			ViewBag.totalUserCount = c.Users.Count();
			ViewBag.vehicleCount = c.Vehicles.Count();
			return View();
		}
	}
}
