using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TranspolarProject.ViewComponents.About
{
	public class _AboutQuestion2 : ViewComponent
	{
		Question2Manager question2Manager = new Question2Manager(new EfQuestion2Dal());
		public IViewComponentResult Invoke()
		{
			var values = question2Manager.TGetListAll().Take(4).ToList();
			return View(values);
		}
	}
}
