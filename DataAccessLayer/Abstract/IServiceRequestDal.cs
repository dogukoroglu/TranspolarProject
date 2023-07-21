using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IServiceRequestDal : IGenericDal<ServiceRequest>
	{
		List<ServiceRequest> GetListRequestWithCustomerName();
		void ChangeStatusApprove(int id);
		void ChangeStatusCansel(int id);
		void ChangeStatusCompleted(int id);
	}
}
