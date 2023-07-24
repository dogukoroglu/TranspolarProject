using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.Controllers
{
	[AllowAnonymous]
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public PartialViewResult SubscribeMail()
		{
			return PartialView();
		}

		[HttpPost]
		public IActionResult SubscribeMail(NewsLetter newsLetter)
		{
			NewsLetterManager newsLetterManager = new NewsLetterManager(new EfNewsLetterDal());
			newsLetterManager.TAdd(newsLetter);
			return RedirectToAction("Index", "Default");
		}
	}
}
