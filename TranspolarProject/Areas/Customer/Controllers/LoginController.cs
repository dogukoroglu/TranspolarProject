using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
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
			Random random = new Random();
			int code;
			code = random.Next(100000, 1000000);
			AppUser appUser = new AppUser()
			{
				Name = model.Name,
				Surname = model.Surname,
				Email = model.Mail,
				UserName = model.Username,
				PhoneNumber = model.Phone,
				ImageUrl = "test",
				Gender = "test",
				ConfirmCode = code
			};
			if (model.Password == model.ConfirmPassword)
			{
				var result = await _userManager.CreateAsync(appUser, model.Password);
				if (result.Succeeded)
				{
					MimeMessage mimeMessage = new MimeMessage();
					MailboxAddress mailboxAddressFrom = new MailboxAddress("Transpolar Admin", "traversalmarsyasx@gmail.com");
					MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);

					mimeMessage.From.Add(mailboxAddressFrom);
					mimeMessage.To.Add(mailboxAddressTo);

					var bodyBuilder = new BodyBuilder();
					bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz:" + code;
					mimeMessage.Body = bodyBuilder.ToMessageBody();

					mimeMessage.Subject = "Transpolar Kullanıcı Kayıt Onay Kodu";

					SmtpClient client = new SmtpClient();
					client.Connect("smtp.gmail.com",587, false);
					client.Authenticate("traversalmarsyasx@gmail.com", "nmokzqqyfikjytdv");
					client.Send(mimeMessage);
					client.Disconnect(true);

					TempData["Mail"] = model.Mail;

					return RedirectToAction("Index","ConfirmMail", new { area = "Customer" });
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
					var user = await _userManager.FindByNameAsync(model.Username);
					if(user.EmailConfirmed == true)
					{
					return RedirectToAction("Index", "Dashboard", new { area = "Customer" });
					}
				}
				//else
				//{
				//	return RedirectToAction("SignIn", "Login");
				//}
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
