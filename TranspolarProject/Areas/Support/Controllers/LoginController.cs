using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TranspolarProject.Areas.Support.Models;

namespace TranspolarProject.Areas.Support.Controllers
{
	[AllowAnonymous]
	[Area("Support")]
	[Route("Support/Login")]
	public class LoginController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet]
		[Route("SignUp")]
		public IActionResult SignUp()
		{
			return View();
		}

		[HttpPost]
		[Route("SignUp")]
		public async Task<IActionResult> SignUp(UserRegisterViewModel model)
		{
			AppUser appUser = new AppUser()
			{
				Name = model.Name,
				Surname = model.Surname,
				Email = model.Mail,
				UserName = model.Username,
				ImageUrl = "Test",
				Gender = "Test"
			};
			if (model.Password == model.ConfirmPassword)
			{
				var result = await _userManager.CreateAsync(appUser, model.Password);
				if (result.Succeeded)
				{
					return RedirectToAction("SignIn", new { area = "Support" });
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View(model);
		}

		[HttpGet]
		[Route("SignIn")]
		public IActionResult SignIn()
		{
			return View();
		}

		[HttpPost]
		[Route("SignIn")]
		public async Task<IActionResult> SignIn(UserSignInViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, true);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Profile");
				}
				else
				{
					return RedirectToAction("SignIn", "Login");
				}
			}
			return View();
		}

		[Route("Logout")]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("SignIn", "Login", new { area = "Support" });
		}
	}
}
