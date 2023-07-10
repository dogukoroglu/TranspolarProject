using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.Areas.Member.Controllers.Services
{
	[Area("Member")]
	[Route("Member/Services")]
	public class ServicesController : Controller
	{
		ServiceManager serviceManager = new ServiceManager(new EfServiceDal());

		[Route("")]
		[Route("Index")]
		public IActionResult Index()
		{
			var values = serviceManager.TGetListAll();
			return View(values);
		}

		[Route("")]
		[Route("AddService")]
		[HttpGet]
		public IActionResult AddService()
		{
			return View();
		}

		[Route("")]
		[Route("AddService")]
		[HttpPost]
		public IActionResult AddService(Service service)
		{
			serviceManager.TAdd(service);
			return RedirectToAction("Index");
		}

		[Route("EditService/{id}")]
		[HttpGet]
		public IActionResult EditService(int id)
		{
			var value = serviceManager.TGetByID(id);
			return View(value);
		}

		[Route("EditService/{id}")]
		[HttpPost]
		public IActionResult EditService(Service service)
		{
			serviceManager.TUpdate(service);
			return RedirectToAction("Index");
		}

		

		[Route("")]
		[Route("DeleteService/{id}")]
		public IActionResult DeleteService(int id)
		{
			var values = serviceManager.TGetByID(id);
			serviceManager.TDelete(values);
			return RedirectToAction("Index");
		}
	}
}
