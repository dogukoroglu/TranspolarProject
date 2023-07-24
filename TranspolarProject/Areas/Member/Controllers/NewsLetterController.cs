using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/NewsLetter")]
	public class NewsLetterController : Controller
	{
		NewsLetterManager newsLetterManager = new NewsLetterManager(new EfNewsLetterDal());

		[Route("Index")]
		public IActionResult Index()
		{
			var values = newsLetterManager.TGetListAll();
			return View(values);
		}
	}
}
