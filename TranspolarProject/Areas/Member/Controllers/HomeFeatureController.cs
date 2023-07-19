using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace TranspolarProject.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/HomeFeature")]
	[Authorize(Roles = "Admin")]

	public class HomeFeatureController : Controller
	{
		HomeFeatureManager homeFeatureManager = new HomeFeatureManager(new EfHomeFeatureDal());

		[Route("Index")]
		public IActionResult Index()
		{
			var values = homeFeatureManager.TGetListAll();
			return View(values);
		}

		//[Route("AddHomeFeature")]
		//[HttpGet]
		//public IActionResult AddHomeFeature()
		//{
		//	return View();
		//}

		//[Route("AddHomeFeature")]
		//[HttpPost]
		//public IActionResult AddHomeFeature(HomeFeature homeFeature)
		//{
		//	homeFeatureManager.TAdd(homeFeature);
		//	return RedirectToAction("Index");
		//}

		[Route("EditHomeFeature/{id}")]
		[HttpGet]
		public IActionResult EditHomeFeature(int id)
		{
			var value = homeFeatureManager.TGetByID(id);
			return View(value);
		}

		[Route("EditHomeFeature/{id}")]
		[HttpPost]
		public IActionResult EditHomeFeature(HomeFeature homeFeature)
		{
			homeFeatureManager.TUpdate(homeFeature);
			return RedirectToAction("Index");
		}

		[Route("DeleteHomeFeature/{id}")]
		public IActionResult DeleteHomeFeature(int id)
		{
			var value = homeFeatureManager.TGetByID(id);
			homeFeatureManager.TDelete(value);
			return RedirectToAction("Index");
		}

	}
}
