using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TranspolarProject.Areas.Support.ViewComponents
{
	public class _SupportNavbarNotificationPartial : ViewComponent
	{
		ServiceRequestManager serviceRequestManager = new ServiceRequestManager(new EfServiceRequestDal());
		public IViewComponentResult Invoke()
		{
			string requestStatus = "Onay Bekliyor";
			var values = serviceRequestManager.TGetListAll().Where(x=>x.Status == requestStatus).OrderByDescending(x=>x.ServiceRequestID).Take(3).ToList();	
			return View(values);
		}
	}
}
