using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace TranspolarProject.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/Address")]
	[Authorize(Roles = "Admin")]
	public class AddressController : Controller
	{
		Contact2Manager contact2Manager = new Contact2Manager(new EfContact2Dal());

		[Route("Index")]
		[HttpGet]
		public IActionResult Index()
		{
			var value = contact2Manager.TGetByID(1);
			return View(value);
		}


		[Route("Index")]
		[HttpPost]
		public IActionResult Index(Contact2 contact2)
		{
			contact2Manager.TUpdate(contact2);
			return RedirectToAction("Index");
		}
	}
}
