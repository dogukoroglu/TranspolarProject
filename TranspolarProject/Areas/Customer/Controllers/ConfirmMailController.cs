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
	[Route("Customer/ConfirmMail")]
	public class ConfirmMailController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public ConfirmMailController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[Route("Index")]
		[HttpGet]
		public IActionResult Index()
		{
			var value = TempData["Mail"];
			ViewBag.registerMail = value;
			return View();
		}

		[Route("Index")]
		[HttpPost]
		public async Task<IActionResult> Index(ConfirmMailViewModel confirmMailViewModel)
		{
			var user = await _userManager.FindByEmailAsync(confirmMailViewModel.Mail);
			if(user.ConfirmCode == confirmMailViewModel.ConfirmCode)
			{
				user.EmailConfirmed = true;
				await _userManager.UpdateAsync(user);
				return RedirectToAction("SignIn", "Login", new { area = "Customer" });
			}
			return View();
		}
	}
}
