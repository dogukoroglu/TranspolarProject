using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TranspolarProject.Areas.Customer.Models;

namespace TranspolarProject.Areas.Customer.Controllers
{
	[Area("Customer")]
	[Route("Customer/[controller]/[action]")]
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
			var value = await _userManager.FindByNameAsync(User.Identity.Name);
			CustomerUserEditViewModel model = new CustomerUserEditViewModel();
			model.Name = value.Name;
			model.Surname = value.Surname;
			model.Email = value.Email;
			model.Phonenumber = value.PhoneNumber;
			model.Gender = value.Gender;
			model.ImageUrl = value.ImageUrl;
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Index(CustomerUserEditViewModel model)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);

			user.Name = model.Name;
			user.Surname = model.Surname;
			user.Email = model.Email;
			user.PhoneNumber = model.Phonenumber;
			user.Gender = model.Gender;
			user.ImageUrl = model.ImageUrl;
			user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);

			var result = await _userManager.UpdateAsync(user);
			if (result.Succeeded)
			{
				return RedirectToAction("SignIn", "Login");
			}
			return View();
		}
	}
}
