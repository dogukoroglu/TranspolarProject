using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.Areas.Member.Controllers
{
	[Area("Member")]
	[AllowAnonymous]
	public class StaffController : Controller
	{
		StaffManager staffManager = new StaffManager(new EfStaffDal());
		public IActionResult Index()
		{
			var values = staffManager.TGetListAll();
			return View(values);
		}
	}
}
