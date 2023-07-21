using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.Areas.Member.ViewComponents
{
    public class _MemberDashboardRequestListPartial : ViewComponent
    {
        ServiceRequestManager serviceRequestManager = new ServiceRequestManager(new EfServiceRequestDal());
        public IViewComponentResult Invoke()
        {
            var values = serviceRequestManager.TGetListRequestWithCustomerName();
            return View(values);
        }
    }
}
