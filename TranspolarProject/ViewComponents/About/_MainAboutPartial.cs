using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.ViewComponents.About
{
	public class _MainAboutPartial : ViewComponent
	{
		AboutManager aboutManager = new AboutManager(new EfAboutDal());
		public IViewComponentResult Invoke()
		{
			var values = aboutManager.TGetListAll();
			return View(values);
		}
	}
}
