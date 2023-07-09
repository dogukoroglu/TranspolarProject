using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TranspolarProject.ViewComponents.About
{
	public class _AboutTeamPartial : ViewComponent
	{
		StaffManager staffManager = new StaffManager(new EfStaffDal());
		public IViewComponentResult Invoke()
		{
			var values = staffManager.TGetListAll().Take(3).ToList();
			return View(values);	
		}
	}
}
