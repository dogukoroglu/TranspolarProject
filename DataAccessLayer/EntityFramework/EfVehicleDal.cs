using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfVehicleDal : GenericRepository<Vehicle>, IVehicleDal
    {
		public void ChangeStatusGarage(int id)
		{
			using var c = new Context();
			Vehicle vehicle = c.Vehicles.Find(id);
			vehicle.VehicleStatus = "Garajda";
			c.SaveChanges();
		}

		public void ChangeStatusRoad(int id)
		{
			using var c = new Context();
			Vehicle vehicle = c.Vehicles.Find(id);
			vehicle.VehicleStatus = "Yolda";
			c.SaveChanges();
		}

		public void ChangeStatusRepair(int id)
		{
			using var c = new Context();
			Vehicle vehicle = c.Vehicles.Find(id);
			vehicle.VehicleStatus = "Serviste";
			c.SaveChanges();
		}
	}
}
