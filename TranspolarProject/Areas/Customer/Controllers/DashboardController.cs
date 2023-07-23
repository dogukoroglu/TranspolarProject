using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TranspolarProject.Areas.Customer.Controllers
{
	[Area("Customer")]
	[Route("Customer/Dashboard")]
	[Authorize(Roles = "Admin,Customer")]

	public class DashboardController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public DashboardController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			var logginUser = await _userManager.FindByNameAsync(User.Identity.Name);
			Context c = new Context();
			//ViewBag.lastRequestStatus = c.ServiceRequests.Where(x => x.AppUserID == logginUser.Id);
			ViewBag.lastRequestStatus = c.ServiceRequests.OrderByDescending(x => x.ServiceRequestID).FirstOrDefault(x => x.AppUserID == logginUser.Id).Status;
			ViewBag.totalRequestCount = c.ServiceRequests.Where(x => x.AppUserID == logginUser.Id).Count();
			//ViewBag.unreadMessageCount = c.SupportMessages.Where(x=>x.Receiver == logginUser.Email).Select(y=>y.Status == false).Count();	
			ViewBag.unreadMessageCount = c.SupportMessages.Where(x => x.Receiver == logginUser.Email && x.Status == false).Count();
			ViewBag.readMessageCount = c.SupportMessages.Where(x => x.Receiver == logginUser.Email && x.Status == true).Count();
			return View();
		}
	}
}
