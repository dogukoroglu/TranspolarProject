using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace TranspolarProject.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/FeaturedService")]
	[Authorize(Roles = "Admin")]

	public class FeaturedServiceController : Controller
	{
		FeaturedServiceManager featuredServiceManager = new FeaturedServiceManager(new EfFeaturedServiceDal());

		[Route("Index")]
		public IActionResult Index()
		{
			var values = featuredServiceManager.TGetListAll();
			return View(values);
		}

		[Route("AddFeaturedService")]
		[HttpGet]
		public IActionResult AddFeaturedService()
		{
			return View();
		}

		[Route("AddFeaturedService")]
		[HttpPost]
		public IActionResult AddFeaturedService(FeaturedService featuredService)
		{
			featuredServiceManager.TAdd(featuredService);
			return RedirectToAction("Index");
		}

		[Route("DeleteFeaturedService/{id}")]
		public IActionResult DeleteFeaturedService(int id)
		{
			var value = featuredServiceManager.TGetByID(id);
			featuredServiceManager.TDelete(value);
			return RedirectToAction("Index");
		}

		[Route("EditFeaturedService/{id}")]
		[HttpGet]
		public IActionResult EditFeaturedService(int id)
		{
			var value = featuredServiceManager.TGetByID(id);
			return View(value);
		}

		[Route("EditFeaturedService/{id}")]
		[HttpPost]
		public IActionResult EditFeaturedService(FeaturedService featuredService)
		{
			featuredServiceManager.TUpdate(featuredService);
			return RedirectToAction("Index");
		}

	}
}
