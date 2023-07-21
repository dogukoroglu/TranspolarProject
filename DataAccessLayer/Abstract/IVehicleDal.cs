using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IVehicleDal : IGenericDal<Vehicle>
    {
		void ChangeStatusGarage(int id);
		void ChangeStatusRoad(int id);
		void ChangeStatusRepair(int id);
	}
}
