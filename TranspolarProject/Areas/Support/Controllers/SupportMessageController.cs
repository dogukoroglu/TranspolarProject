using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TranspolarProject.Areas.Support.Controllers
{
	[Area("Support")]
	[Route("Support/SupportMessage")]
	[Authorize(Roles = "Admin,Support")]

	public class SupportMessageController : Controller
	{
		SupportMessageManager supportMessageManager = new SupportMessageManager(new EfSupportMessageDal());
		private readonly UserManager<AppUser> _userManager;

		public SupportMessageController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[Route("ReceiverMessage")]
		public async Task<IActionResult> ReceiverMessage(string p)
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			p = values.Email;
			var messageList = supportMessageManager.TGetListReceiverMessage(p);
			return View(messageList);
		}

		[Route("SenderMessage")]
		public async Task<IActionResult> SenderMessage(string p)
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			p = values.Email;
			var messageList = supportMessageManager.TGetListSenderMessage(p);
			return View(messageList);
		}

		[Route("SenderMessageDetails/{id}")]
		public IActionResult SenderMessageDetails(int id)
		{
			SupportMessage supportMessage = supportMessageManager.TGetByID(id);
			return View(supportMessage);
		}

		[Route("ReceiverMessageDetails/{id}")]
		public IActionResult ReceiverMessageDetails(int id)
		{
			SupportMessage supportMessage = supportMessageManager.TGetByID(id);
			return View(supportMessage);
		}

		[Route("SendMessage")]
		[HttpGet]
		public async Task<IActionResult> SendMessage()
		{
			Context c = new Context();
			var logginUser = await _userManager.FindByNameAsync(User.Identity.Name);
			List<SelectListItem> customerList = (from x in c.Users.ToList()
												 where x.Email != logginUser.Email
												 select new SelectListItem
												 {
													 Text = x.Name + " " + x.Surname,
													 Value = x.Email
												 }).ToList();
			ViewBag.customerList = customerList;
			return View();
		}

		[Route("SendMessage")]
		[HttpPost]
		public async Task<IActionResult> SendMessage(SupportMessage supportMessage)
		{
			Context c = new Context();
			var receiverName = c.Users.Where(x=>x.Email == supportMessage.Receiver).Select(y=>y.Name+" " + y.Surname).FirstOrDefault();
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			string mail = values.Email;
			string name = values.Name + " " + values.Surname;
			supportMessage.Date = DateTime.Parse(DateTime.Now.ToString());
			supportMessage.Sender = mail;
			supportMessage.SenderName = name;
			supportMessage.ReceiverName = receiverName;
			supportMessageManager.TAdd(supportMessage);
			return RedirectToAction("SenderMessage");
		}

	}
}
