using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TranspolarProject.Areas.Customer.Controllers
{
	[Area("Customer")]
	[Route("Customer/Testimonial")]
	[Authorize(Roles ="Customer,Admin")]
	public class TestimonialController : Controller
	{
		TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());
		private readonly UserManager<AppUser> _userManager;

		public TestimonialController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		[Route("AddComment")]
		public IActionResult AddComment()
		{
			return View();
		}

		[HttpPost]
		[Route("AddComment")]
		public async Task<IActionResult> AddComment(Testimonial testimonial)
		{
			var logginUser = await _userManager.FindByNameAsync(User.Identity.Name);
			testimonial.Client = logginUser.Name + " " + logginUser.Surname;
			testimonial.ClientImage = logginUser.ImageUrl;
			testimonial.ClientJob = "Test";
			testimonialManager.TAdd(testimonial);
			return RedirectToAction("Index","Dashboard");
		}

		//[Route("CommentDetails/{id}")]
		//[HttpGet]
		//public IActionResult CommentDetails(int id)
		//{
		//	var value = testimonialManager.TGetByID(id);
		//	return View(value);
		//}

		//[Route("CommentDetails/{id}")]
		//[HttpPost]
		//public IActionResult CommentDetails(Testimonial testimonial)
		//{
		//	testimonialManager.TUpdate(testimonial);
		//	return RedirectToAction("CommentDetails");
		//}
	}
}
