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
	public class StaffManager : IStaffService
	{
		IStaffDal _staffDal;

		public StaffManager(IStaffDal staffDal)
		{
			_staffDal = staffDal;
		}

		public void TAdd(Staff t)
		{
			_staffDal.Insert(t);
		}

		public void TDelete(Staff t)
		{
			_staffDal.Delete(t);
		}

		public Staff TGetByID(int id)
		{
			return _staffDal.GetByID(id);
		}

		public List<Staff> TGetListAll()
		{
			return _staffDal.GetListAll();
		}

		public void TUpdate(Staff t)
		{
			_staffDal.Update(t);
		}
	}
}
