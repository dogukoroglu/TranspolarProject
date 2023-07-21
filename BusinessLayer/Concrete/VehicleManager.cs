using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class VehicleManager : IVehicleService
    {
        IVehicleDal _vehicleDal;

        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }

        public void TAdd(Vehicle t)
        {
            _vehicleDal.Insert(t);
        }

		public void TChangeStatusGarage(int id)
		{
            _vehicleDal.ChangeStatusGarage(id);
		}

		public void TChangeStatusRepair(int id)
		{
            _vehicleDal.ChangeStatusRepair(id);
		}

		public void TChangeStatusRoad(int id)
		{
            _vehicleDal.ChangeStatusRoad(id);
		}

		public void TDelete(Vehicle t)
        {
            _vehicleDal.Delete(t);
        }

        public Vehicle TGetByID(int id)
        {
            return _vehicleDal.GetByID(id); 
        }

        public List<Vehicle> TGetListAll()
        {
            return _vehicleDal.GetListAll();
        }

        public void TUpdate(Vehicle t)
        {
            _vehicleDal.Update(t);
        }
    }
}
