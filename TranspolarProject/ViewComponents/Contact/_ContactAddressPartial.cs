using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.ViewComponents.Contact
{
    public class _ContactAddressPartial :ViewComponent
    {
        Contact2Manager contact2Manager = new Contact2Manager(new EfContact2Dal());
        public IViewComponentResult Invoke()
        {
            var values = contact2Manager.TGetListAll();
            return View(values);
        }
    }
}
