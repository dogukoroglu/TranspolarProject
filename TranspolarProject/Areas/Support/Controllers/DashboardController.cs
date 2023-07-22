using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace TranspolarProject.Areas.Support.Controllers
{
	[Area("Support")]
	[Route("Support/Dashboard")]
	[Authorize(Roles ="Support")]
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
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			Context c = new Context();
			ViewBag.requestCount = c.ServiceRequests.Count();
			ViewBag.vehicleCount = c.Vehicles.Count();
			ViewBag.incomingMessageCount = c.SupportMessages.Where(x=>x.Receiver == values.Email).Count();
			ViewBag.outgoingMessageCount = c.SupportMessages.Where(x=>x.Sender == values.Email).Count();
			return View();
		}
	}
}
