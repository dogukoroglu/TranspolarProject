using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace TranspolarProject.Areas.Customer.ViewComponents
{
	public class _CustomerDashboardRequestList : ViewComponent
	{
		ServiceRequestManager serviceRequestManager = new ServiceRequestManager(new EfServiceRequestDal());
		private readonly UserManager<AppUser> _userManager;

		public _CustomerDashboardRequestList(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var logginUser = await _userManager.FindByNameAsync(User.Identity.Name);
			var values = serviceRequestManager.GetListAllRequest(logginUser.Id);
			return View(values);
		}
	}
}
