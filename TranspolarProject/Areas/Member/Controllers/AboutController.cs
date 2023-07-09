using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/About")]
	public class AboutController : Controller
	{
		AboutManager aboutManager = new AboutManager(new EfAboutDal());

		[Route("")]
		[Route("Index")]
		[HttpGet]
		public IActionResult Index()
		{
			var value = aboutManager.TGetByID(1);
			return View(value);
		}

		[Route("")]
		[Route("Index")]
		[HttpPost]
		public IActionResult Index(About about)
		{
			aboutManager.TUpdate(about);
			return RedirectToAction("Index");
		}
	}
}
