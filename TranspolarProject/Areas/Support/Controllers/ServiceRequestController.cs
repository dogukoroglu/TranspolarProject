using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace TranspolarProject.Areas.Support.Controllers
{
	[Area("Support")]
	[Route("Support/ServiceRequest")]
	[Authorize(Roles ="Admin,Support")]
	public class ServiceRequestController : Controller
	{
		ServiceRequestManager serviceRequestManager = new ServiceRequestManager(new EfServiceRequestDal());
		private readonly UserManager<AppUser> _userManager;

		public ServiceRequestController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[Route("Index")]
		public IActionResult Index()
		{
			var values = serviceRequestManager.TGetListRequestWithCustomerName();
			return View(values);
		}

		[Route("RequestDetails/{id}")]
		[HttpGet]
		public IActionResult RequestDetails(int id)
		{
			var value = serviceRequestManager.TGetByID(id);
			return View(value);
		}

		[Route("RequestDetails/{id}")]
		[HttpPost]
		public IActionResult RequestDetails(ServiceRequest serviceRequest)
		{
			serviceRequestManager.TUpdate(serviceRequest);
			return RedirectToAction("Index");
		}

		[Route("ChangeStatusApprove/{id}")]
		public IActionResult ChangeStatusApprove(int id)
		{
			serviceRequestManager.TChangeStatusApprove(id);
			return RedirectToAction("Index");
		}

		[Route("ChangeStatusCompleted/{id}")]
		public IActionResult ChangeStatusCompleted(int id)
		{
			serviceRequestManager.TChangeStatusCompleted(id);
			return RedirectToAction("Index");
		}

		[Route("ChangeStatusCansel/{id}")]
		public IActionResult ChangeStatusCansel(int id)
		{
			serviceRequestManager.TChangeStatusCansel(id);
			return RedirectToAction("Index");
		}

	}
}
