using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.ViewComponents.Service
{
	public class _ServiceAboutPartial : ViewComponent
	{
		AboutManager aboutManager = new AboutManager(new EfAboutDal());
		public IViewComponentResult Invoke()
		{
			var values = aboutManager.TGetListAll();
			return View(values);
		}
	}
}
