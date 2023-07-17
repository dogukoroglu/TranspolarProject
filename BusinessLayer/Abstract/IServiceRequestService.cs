using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IServiceRequestService : IGenericService<ServiceRequest>
	{
		List<ServiceRequest> GetListApprovalRequest(int id);
		List<ServiceRequest> GetListCurrentRequest(int id);
		List<ServiceRequest> GetListOldRequest(int id);
	}
}
