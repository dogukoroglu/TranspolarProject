using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TranspolarProject.Areas.Customer.Models;

namespace TranspolarProject.Areas.Customer.Controllers
{
	[AllowAnonymous]
	[Area("Customer")]
	[Route("Customer/Login")]
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
				PhoneNumber = model.Phone,
				ImageUrl = "test",
				Gender = "test"
			};
			if (model.Password == model.ConfirmPassword)
			{
				var result = await _userManager.CreateAsync(appUser, model.Password);
				if (result.Succeeded)
				{
					return RedirectToAction("SignIn", new { area = "Customer" });
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
					return RedirectToAction("Index", "Dashboard", new { area = "Customer" });
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
			return RedirectToAction("SignIn", "Login",new {area="Customer"});
		}
	}
}
