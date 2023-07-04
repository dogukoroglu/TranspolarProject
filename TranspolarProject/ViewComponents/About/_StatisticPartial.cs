using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TranspolarProject.ViewComponents.About
{
	public class _StatisticPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			using var c = new Context();
			ViewBag.staffCount = c.Staffs.Count();
			ViewBag.serviceCount = c.Services.Count();
			ViewBag.testimonialsCount = c.Testimonials.Count();
			ViewBag.totalVehicles = "42";
			return View();
		}
	}
}
