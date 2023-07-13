using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/Question2")]
	public class Question2Controller : Controller
	{
		Question2Manager question2Manager = new Question2Manager(new EfQuestion2Dal());

		[Route("Index")]
		public IActionResult Index()
		{
			var values = question2Manager.TGetListAll();
			return View(values);
		}

		[Route("DeleteQuestion/{id}")]
		public IActionResult DeleteQuestion(int id)
		{
			var value = question2Manager.TGetByID(id);
			question2Manager.TDelete(value);
			return RedirectToAction("Index");	
		}

		[Route("EditQuestion/{id}")]
		[HttpGet]
		public IActionResult EditQuestion(int id)
		{
			var value = question2Manager.TGetByID(id);
			return View(value);
		}

		[Route("EditQuestion/{id}")]
		[HttpPost]
		public IActionResult EditQuestion(Question2 question2)
		{
			question2Manager.TUpdate(question2);
			return RedirectToAction("Index");
		}
	}
}
