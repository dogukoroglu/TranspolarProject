using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.ViewComponents.Service
{
    public class _ServiceFeaturedServicePartial : ViewComponent
    {
        FeaturedServiceManager featuredServiceManager = new FeaturedServiceManager(new EfFeaturedServiceDal());
        public IViewComponentResult Invoke()
        {
            var values = featuredServiceManager.TGetListAll();
            return View(values);
        }
    }
}
