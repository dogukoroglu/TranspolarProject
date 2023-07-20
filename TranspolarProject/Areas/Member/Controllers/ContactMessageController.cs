using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/ContactMessage")]
    [Authorize(Roles ="Admin")]
    public class ContactMessageController : Controller
    {
        ContactMessageManager contactMessageManager = new ContactMessageManager(new EfContactMessageDal());

        [Route("Index")]
        public IActionResult Index()
        {
            var values = contactMessageManager.TGetListAll();
            return View(values);
        }

        [HttpGet]
		[Route("MessageDetails/{id}")]
		public IActionResult MessageDetails(int id)
        {
            var value = contactMessageManager.TGetByID(id);
            return View(value);
        }
	}
}
