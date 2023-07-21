using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.Areas.Support.Controllers
{
    [Area("Support")]
    [Route("Support/Vehicle")]
    public class VehicleController : Controller
    {
        VehicleManager vehicleManager = new VehicleManager(new EfVehicleDal());

        [Route("VehicleList")]
        public IActionResult VehicleList()
        {
            var values = vehicleManager.TGetListAll();
            return View(values);
        }

        [HttpGet]
        [Route("AddVehicle")]
        public IActionResult AddVehicle()
        {
            return View();
        }

        [HttpPost]
        [Route("AddVehicle")]
        public IActionResult AddVehicle(Vehicle vehicle)
        {
            vehicle.VehicleStatus = "Garajda";
            vehicleManager.TAdd(vehicle);
            return RedirectToAction("VehicleList");
        }

        [HttpGet]
		[Route("VehicleDetail/{id}")]
		public IActionResult VehicleDetail(int id)
        {
            var value = vehicleManager.TGetByID(id);
            return View(value);
        }

		[HttpPost]
		[Route("VehicleDetail/{id}")]
		public IActionResult VehicleDetail(Vehicle vehicle)
		{
            vehicleManager.TUpdate(vehicle);
            return RedirectToAction("VehicleList");
		}

		[Route("DeleteVehicle/{id}")]
		public IActionResult DeleteVehicle(int id)
        {
            var value = vehicleManager.TGetByID(id);
            vehicleManager.TDelete(value);
            return RedirectToAction("VehicleList");
        }

		[Route("ChangeVehicleStatusGarage/{id}")]
        public IActionResult ChangeVehicleStatusGarage(int id)
        {
            vehicleManager.TChangeStatusGarage(id);
			return RedirectToAction("VehicleList");
		}

		[Route("ChangeVehicleStatusRoad/{id}")]
		public IActionResult ChangeVehicleStatusRoad(int id)
		{
			vehicleManager.TChangeStatusRoad(id);
			return RedirectToAction("VehicleList");
		}

		[Route("ChangeVehicleStatusRepair/{id}")]
		public IActionResult ChangeVehicleStatusRepair(int id)
		{
			vehicleManager.TChangeStatusRepair(id);
			return RedirectToAction("VehicleList");
		}
	}
}
