using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace TranspolarProject.Areas.Customer.ViewComponents
{
	public class _CustomerDashboardIncomingMessageList : ViewComponent
	{
		SupportMessageManager supportMessageManager = new SupportMessageManager(new EfSupportMessageDal());
		private readonly UserManager<AppUser> _userManager;

		public _CustomerDashboardIncomingMessageList(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var logginUser = await _userManager.FindByNameAsync(User.Identity.Name);
			var values = supportMessageManager.TGetListAll().Where(x => x.Receiver == logginUser.Email).OrderByDescending(x=>x.MessageID).Take(3).ToList();	
			return View(values);
		}
	}
}
