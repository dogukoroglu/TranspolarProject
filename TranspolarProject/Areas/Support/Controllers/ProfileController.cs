using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TranspolarProject.Areas.Support.Models;

namespace TranspolarProject.Areas.Support.Controllers
{
    [Area("Support")]
	[Route("Support/[controller]/[action]")]
	[Authorize(Roles = "Admin,Support")]

	public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

		public ProfileController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			SupportUserEditViewModel supportUserEditViewModel = new SupportUserEditViewModel();
			supportUserEditViewModel.Name = values.Name;
			supportUserEditViewModel.Surname = values.Surname;
			supportUserEditViewModel.Email = values.Email;
			supportUserEditViewModel.Gender = values.Gender;
			supportUserEditViewModel.ImageUrl = values.ImageUrl;
			return View(supportUserEditViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Index(SupportUserEditViewModel model)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);

			user.Name = model.Name;
			user.Surname = model.Surname;
			user.Email = model.Email;
			user.Gender = model.Gender;	
			user.ImageUrl = model.ImageUrl;
			user.PasswordHash = _userManager.PasswordHasher.HashPassword(user,model.Password);

			var result = await _userManager.UpdateAsync(user);
			if (result.Succeeded)
			{
				return RedirectToAction("SignIn", "Login");
			}
			return View();
		}
	}
}
