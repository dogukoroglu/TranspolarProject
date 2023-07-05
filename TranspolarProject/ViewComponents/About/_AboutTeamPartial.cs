using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.ViewComponents.About
{
	public class _AboutTeamPartial : ViewComponent
	{
		StaffManager staffManager = new StaffManager(new EfStaffDal());
		public IViewComponentResult Invoke()
		{
			var values = staffManager.TGetListAll();
			return View(values);	
		}
	}
}
