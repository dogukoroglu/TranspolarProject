using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.ViewComponents.UILayout
{
	public class _FooterSocialMediaPartial : ViewComponent
	{
		SocialMediaManager socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());
		public IViewComponentResult Invoke()
		{
			var values = socialMediaManager.TGetListAll();
			return View(values);
		}
	}
}
