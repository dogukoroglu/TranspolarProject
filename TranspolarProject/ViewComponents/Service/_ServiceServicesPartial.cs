using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.ViewComponents.Service
{
	public class _ServiceServicesPartial : ViewComponent
	{
		ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
		public IViewComponentResult Invoke()
		{
			var values = serviceManager.TGetListAll();
			return View(values);
		}
	}
}
