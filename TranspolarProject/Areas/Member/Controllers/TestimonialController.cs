using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace TranspolarProject.Areas.Member.Controllers
{
	[Area("Member")]
    [Route("Member/Testimonial")]
	[Authorize(Roles = "Admin")]

	public class TestimonialController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());

        [Route("Index")]
        public IActionResult Index()
        {
            var value = testimonialManager.TGetListAll();
            return View(value);
        }

        [Route("TestimonialDetails/{id}")]
        [HttpGet]
        public IActionResult TestimonialDetails(int id)
        {
            var value = testimonialManager.TGetByID(id);
            return View(value);
        }

		[Route("DeleteTestimonial/{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = testimonialManager.TGetByID(id);
            testimonialManager.TDelete(value);
            return RedirectToAction("Index");
        }
	}
}
