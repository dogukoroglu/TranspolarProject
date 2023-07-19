using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TranspolarProject.Areas.Customer.Controllers
{
	[Area("Customer")]
	[Route("Customer/ServiceRequest")]
	[Authorize(Roles = "Admin,Customer")]

	public class ServiceRequestController : Controller
	{
		FeaturedServiceManager featuredServiceManager = new FeaturedServiceManager(new EfFeaturedServiceDal());
		ServiceRequestManager serviceRequestManager = new ServiceRequestManager(new EfServiceRequestDal());

		private readonly UserManager<AppUser> _userManager;

		public ServiceRequestController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		/*
		 Dependency Injection kullanarak newlemeden kullanılabilir.
			private readonly IDestinationService _destinationService;
			private readonly IReservationService _reservationService;
			public ReservationController(IDestinationService destinationService, IReservationService reservationService)
				{
					_destinationService = destinationService;
					_reservationService = reservationService;
				}
		 */

		[Route("MyCurrentRequest")]
		public async Task<IActionResult> MyCurrentRequest()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			var valuesList = serviceRequestManager.GetListCurrentRequest(values.Id);
			return View(valuesList);
		}

		[Route("MyOldRequest")]
		public async Task<IActionResult> MyOldRequest()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			var valuesList = serviceRequestManager.GetListOldRequest(values.Id);
			return View(valuesList);
		}

		[Route("MyApprovalRequest")]
		public async Task<IActionResult> MyApprovalRequest()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			var valuesList = serviceRequestManager.GetListApprovalRequest(values.Id);
			return View(valuesList);
		}

		[HttpGet]
		[Route("NewRequest")]
		public IActionResult NewRequest()
		{
			List<SelectListItem> values = (from x in featuredServiceManager.TGetListAll()
										   select new SelectListItem
										   {
											   Text = x.FeaturedTitle,
											   Value = x.FeaturedTitle.ToString()
										   }).ToList();
			ViewBag.v = values;
			return View();
		}

		[HttpPost]
		[Route("NewRequest")]
		public async Task<IActionResult> NewRequest(ServiceRequest serviceRequest)
		{
			var loginCustomer = await _userManager.FindByNameAsync(User.Identity.Name);
			serviceRequest.AppUserID = loginCustomer.Id;
			serviceRequest.Description = "test";
			serviceRequest.Status = "Onay Bekliyor";
			serviceRequestManager.TAdd(serviceRequest);
			return RedirectToAction("MyApprovalRequest");
		}
	}
}
