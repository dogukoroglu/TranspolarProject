using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.ViewComponents.Default
{
	public class _DefaultFeaturedPartial: ViewComponent
	{
		HomeFeatureManager homeFeatureManager = new HomeFeatureManager(new EfHomeFeatureDal());
		public IViewComponentResult Invoke()
		{
			var values = homeFeatureManager.TGetListAll();
			return View(values);	
		}
	}
}
