using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class TestimonialManager : ITestimonialService
	{
		ITestimonialDal _testimonialDal;

		public TestimonialManager(ITestimonialDal testimonialDal)
		{
			_testimonialDal = testimonialDal;
		}

		public void TAdd(Testimonial t)
		{
			_testimonialDal.Insert(t);
		}

		public void TDelete(Testimonial t)
		{
			_testimonialDal.Delete(t);
		}

		public Testimonial TGetByID(int id)
		{
			return _testimonialDal.GetByID(id);
		}

		public List<Testimonial> TGetListAll()
		{
			return _testimonialDal.GetListAll();
		}

		public void TUpdate(Testimonial t)
		{
			_testimonialDal.Update(t);
		}
	}
}
