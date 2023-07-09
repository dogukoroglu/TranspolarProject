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
	public class EfStaffDal : GenericRepository<Staff>, IStaffDal
	{
		public void ChangeStaffStatusTrue(int id)
		{
			using var c = new Context();
			Staff staff = c.Staffs.Find(id);
			staff.Status = true;
			c.SaveChanges();
		}

		public void ChangeStaffStatusFalse(int id)
		{
			using var c = new Context();
			Staff staff = c.Staffs.Find(id);
			staff.Status = false;
			c.SaveChanges();
		}
	}
}
