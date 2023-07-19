using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/ContactAbout")]
    [Authorize(Roles ="Admin")]
    public class ContactAboutController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());

        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            var value = contactManager.TGetByID(1);
            return View(value);
        }


		[Route("Index")]
		[HttpPost]
		public IActionResult Index(Contact contact)
		{
			contactManager.TUpdate(contact);
			return RedirectToAction("Index");
		}
	}
}
