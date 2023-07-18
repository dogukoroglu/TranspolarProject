using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TranspolarProject.Areas.Support.ViewComponents
{
	public class _SupportNavbarUserProfile : ViewComponent
	{
		private readonly UserManager<AppUser> _userManager;

		public _SupportNavbarUserProfile(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var value = await _userManager.FindByNameAsync(User.Identity.Name);
			ViewBag.userNameSurname = value.Name + " " + value.Surname;
			ViewBag.userProfileImage = value.ImageUrl;
			return View();
		}
	}
}
