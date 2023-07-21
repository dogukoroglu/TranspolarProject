using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfServiceRequestDal : GenericRepository<ServiceRequest>, IServiceRequestDal
	{
		public void ChangeStatusApprove(int id)
		{
			using var c = new Context();
			ServiceRequest serviceRequest = c.ServiceRequests.Find(id);
			serviceRequest.Status = "Onaylandı";
			c.SaveChanges();
		}

		public void ChangeStatusCansel(int id)
		{
			using var c = new Context();
			ServiceRequest serviceRequest = c.ServiceRequests.Find(id);
			serviceRequest.Status = "İptal Edildi";
			c.SaveChanges();
		}

		public void ChangeStatusCompleted(int id)
		{
			using var c = new Context();
			ServiceRequest serviceRequest = c.ServiceRequests.Find(id);
			serviceRequest.Status = "Tamamlandı";
			c.SaveChanges();
		}

		public List<ServiceRequest> GetListRequestWithCustomerName()
		{
			using var c = new Context();
			return c.ServiceRequests.Include(x => x.AppUser).ToList();
		}
	}
}
