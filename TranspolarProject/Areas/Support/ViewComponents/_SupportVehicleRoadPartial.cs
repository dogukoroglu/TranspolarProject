using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TranspolarProject.Areas.Support.ViewComponents
{
    public class _SupportVehicleRoadPartial : ViewComponent
    {
        VehicleManager vehicleManager = new VehicleManager(new EfVehicleDal());
        public IViewComponentResult Invoke()
        {
            var values = vehicleManager.TGetListAll().Where(x=>x.VehicleStatus=="Yolda").ToList();
            return View(values);
        }
    }
}
