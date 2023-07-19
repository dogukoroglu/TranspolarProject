using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using TranspolarProject.Areas.Member.Models;

namespace TranspolarProject.Areas.Member.Controllers
{
	[AllowAnonymous]
	[Area("Member")]
	[Route("Member/Staff")]
	[Authorize(Roles = "Admin")]


	public class StaffController : Controller
	{
		StaffManager staffManager = new StaffManager(new EfStaffDal());

		[Route("")]
		[Route("Index")]
		public IActionResult Index()
		{
			var values = staffManager.TGetListAll();
			return View(values);
		}

		[Route("")]
		[Route("AddStaff")]
		[HttpGet]
		public IActionResult AddStaff()
		{
			return View();
		}

		[Route("")]
		[Route("AddStaff")]
		[HttpPost]
		public IActionResult AddStaff(Staff staff)
		{
			staff.Status = true;
			staffManager.TAdd(staff);
			return RedirectToAction("Index");
		}

		[Route("")]
		[Route("DeleteStaff/{id}")]
		public IActionResult DeleteStaff(int id)
		{
			var value = staffManager.TGetByID(id);
			staffManager.TDelete(value);
			return RedirectToAction("Index");
		}

		[Route("EditStaff/{id}")]
		[HttpGet]
		public IActionResult EditStaff(int id)
		{
			var value = staffManager.TGetByID(id);
			return View(value);
		}

		[Route("EditStaff/{id}")]
		[HttpPost]
		public IActionResult EditStaff(Staff staff)
		{
			Staff existingStaff = staffManager.TGetByID(staff.StaffID);
			staff.Status = existingStaff.Status;
			staffManager.TUpdate(staff);
			return RedirectToAction("Index");
		}

		[Route("")]
		[Route("StatusChangeTrue/{id}")]
		public IActionResult StatusChangeTrue(int id)
		{
			staffManager.TChangeStaffStatusTrue(id);
			return RedirectToAction("Index");
		}

		[Route("")]
		[Route("StatusChangeFalse/{id}")]
		public IActionResult StatusChangeFalse(int id)
		{
			staffManager.TChangeStaffStatusFalse(id);
			return RedirectToAction("Index");
		}
	}
}
