using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IVehicleService : IGenericService<Vehicle>
    {
		void TChangeStatusGarage(int id);
		void TChangeStatusRoad(int id);
		void TChangeStatusRepair(int id);
	}
}
