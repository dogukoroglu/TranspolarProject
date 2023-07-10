using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/About2")]
	public class About2Controller : Controller
	{
		About2Manager about2Manager = new About2Manager(new EfAbout2Dal());

		[Route("")]
		[Route("Index")]
		public IActionResult Index()
		{
			var values = about2Manager.TGetListAll();
			return View(values);
		}

		[Route("UpdateDetails/{id}")]
		[HttpGet]
		public IActionResult UpdateDetails(int id)
		{
			var value = about2Manager.TGetByID(id);
			return View(value);
		}

		[Route("UpdateDetails/{id}")]
		[HttpPost]
		public IActionResult UpdateDetails(About2 about2)
		{
			about2Manager.TUpdate(about2);
			return RedirectToAction("Index");
		}

		[Route("")]
		[Route("DeleteDetails/{id}")]
		public IActionResult DeleteDetails(int id)
		{
			var value = about2Manager.TGetByID(id);
			about2Manager.TDelete(value);
			return RedirectToAction("Index");
		}
	}
}
