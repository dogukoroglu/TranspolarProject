using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TranspolarProject.ViewComponents.Default
{
	public class _TestimonialPartial : ViewComponent
	{
		TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());
		public IViewComponentResult Invoke()
		{
			var values = testimonialManager.TGetListAll().TakeLast(1).ToList();
			return View(values);
		}
	}
}
