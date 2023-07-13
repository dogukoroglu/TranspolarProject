using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TranspolarProject.ViewComponents.About
{
	public class _AboutQuestion : ViewComponent
	{
		QuestionManager questionManager = new QuestionManager(new EfQuestionDal());
		public IViewComponentResult Invoke()
		{
			var values = questionManager.TGetListAll();
			return View(values);
		}
	}
}
