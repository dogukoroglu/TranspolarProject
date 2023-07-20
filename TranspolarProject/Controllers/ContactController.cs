using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;

namespace TranspolarProject.Controllers
{
	[AllowAnonymous]
	public class ContactController : Controller
	{

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public PartialViewResult SendMessage()
		{
			return PartialView();
		}

		[HttpPost]
		public IActionResult SendMessage(ContactMessage contactMessage)
		{
			ContactMessageManager contactMessageManager = new ContactMessageManager(new EfContactMessageDal());
			contactMessage.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			contactMessageManager.TAdd(contactMessage);
			return RedirectToAction("Index","Contact");
		}
	}
}
