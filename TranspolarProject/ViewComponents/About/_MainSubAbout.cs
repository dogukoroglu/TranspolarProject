using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.ViewComponents.About
{
	public class _MainSubAbout : ViewComponent
	{
		About2Manager about2Manager = new About2Manager(new EfAbout2Dal());
		public IViewComponentResult Invoke()
		{
			var values = about2Manager.TGetListAll();
			return View(values);
		}
	}
}
