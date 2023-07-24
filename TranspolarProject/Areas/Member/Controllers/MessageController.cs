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
using System.Linq;
using System.Threading.Tasks;

namespace TranspolarProject.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/Message")]
	[Authorize(Roles ="Admin")]
	public class MessageController : Controller
	{
		SupportMessageManager supportMessageManager = new SupportMessageManager(new EfSupportMessageDal());
		private readonly UserManager<AppUser> _userManager;

		public MessageController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[Route("Inbox")]
		public async Task<IActionResult> Inbox(string p)
		{
			var logginUser = await _userManager.FindByNameAsync(User.Identity.Name);
			p = logginUser.Email;
			var messageList = supportMessageManager.TGetListReceiverMessage(p);
			return View(messageList);
		}

		[Route("Sendbox")]
		public async Task<IActionResult> Sendbox(string p)
		{
			var logginUser = await _userManager.FindByNameAsync(User.Identity.Name);
			p = logginUser.Email;
			var messageList = supportMessageManager.TGetListSenderMessage(p);
			return View(messageList);
		}

		[Route("SenderMessageDetails/{id}")]
		public IActionResult SenderMessageDetails(int id) // Bizim gönderdiğimiz
		{
			SupportMessage supportMessage = supportMessageManager.TGetByID(id);
			return View(supportMessage);
		}

		[Route("ReceiverMessageDetails/{id}")]
		public IActionResult ReceiverMessageDetails(int id) // Bize gönderilen
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
			var receiverName = c.Users.Where(x => x.Email == supportMessage.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			string mail = values.Email;
			string name = values.Name + " " + values.Surname;
			supportMessage.Date = DateTime.Parse(DateTime.Now.ToString());
			supportMessage.Sender = mail;
			supportMessage.SenderName = name;
			supportMessage.ReceiverName = receiverName;
			supportMessageManager.TAdd(supportMessage);
			return RedirectToAction("Sendbox");
		}

		[Route("ChangeStatus/{id}")]
		public IActionResult ChangeStatus(int id)
		{
			supportMessageManager.TChangeMessageStatus(id);
			return RedirectToAction("ReceiverMessage");
		}
	}
}
