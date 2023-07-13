using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/Question")]
	public class QuestionController : Controller
	{
		QuestionManager questionManager = new QuestionManager(new EfQuestionDal());

		[Route("Index")]
		[HttpGet]
		public IActionResult Index()
		{
			var value = questionManager.TGetListAll();
			return View(value);
		}

		[Route("ContentDetails/{id}")]
		[HttpGet]
		public IActionResult ContentDetails(int id)
		{
			var value = questionManager.TGetByID(id);
			return View(value);	
		}

		[Route("ContentDetails/{id}")]
		[HttpPost]
		public IActionResult ContentDetails(Question question)
		{
			questionManager.TUpdate(question);
			return RedirectToAction("Index");
		}
	}
}
