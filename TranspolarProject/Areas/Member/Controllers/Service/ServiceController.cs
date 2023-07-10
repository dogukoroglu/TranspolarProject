using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.Areas.Member.Controllers.Service
{
	[Area("Member")]
	public class ServiceController : Controller
	{
		ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
		public IActionResult Index()
		{
			var values = serviceManager.TGetListAll();
			return View(values);
		}
	}
}
