using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace TranspolarProject.Areas.Member.ViewComponents
{
	public class _NavbarUserNotificationPartial : ViewComponent
	{
		ContactMessageManager contactMessageManager = new ContactMessageManager(new EfContactMessageDal());
		public IViewComponentResult Invoke()
		{
			var values = contactMessageManager.TGetListAll().OrderByDescending(x=>x.ContactDate).Take(3).ToList();
			return View(values);	
		}
	}
}
