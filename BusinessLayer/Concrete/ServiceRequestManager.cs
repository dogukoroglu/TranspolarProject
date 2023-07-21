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
	public class ServiceRequestManager : IServiceRequestService
	{
		IServiceRequestDal _serviceRequestDal;

		public ServiceRequestManager(IServiceRequestDal serviceRequestDal)
		{
			_serviceRequestDal = serviceRequestDal;
		}

		public List<ServiceRequest> GetListAllRequest(int id)
		{
			return _serviceRequestDal.GetListByFilter(x => x.AppUserID == id);
		}

		public List<ServiceRequest> GetListApprovalRequest(int id)
		{
			return _serviceRequestDal.GetListByFilter(x=>x.AppUserID == id && x.Status == "Onay Bekliyor");
		}

		public List<ServiceRequest> GetListCurrentRequest(int id)
		{
			return _serviceRequestDal.GetListByFilter(x => x.AppUserID == id && x.Status == "Onaylandı");
		}

		public List<ServiceRequest> GetListOldRequest(int id)
		{
			return _serviceRequestDal.GetListByFilter(x => x.AppUserID == id && (x.Status == "İptal Edildi" || x.Status == "Tamamlandı"));
		}

		public void TAdd(ServiceRequest t)
		{
			_serviceRequestDal.Insert(t);
		}

		public void TChangeStatusApprove(int id)
		{
			_serviceRequestDal.ChangeStatusApprove(id);
		}

		public void TChangeStatusCansel(int id)
		{
			_serviceRequestDal.ChangeStatusCansel(id);
		}

		public void TChangeStatusCompleted(int id)
		{
			_serviceRequestDal.ChangeStatusCompleted(id);
		}

		public void TDelete(ServiceRequest t)
		{
			_serviceRequestDal.Delete(t);
		}

		public ServiceRequest TGetByID(int id)
		{
			return _serviceRequestDal.GetByID(id);
		}

		public List<ServiceRequest> TGetListAll()
		{
			return _serviceRequestDal.GetListAll();
		}

		public List<ServiceRequest> TGetListRequestWithCustomerName()
		{
			return _serviceRequestDal.GetListRequestWithCustomerName();
		}

		public void TUpdate(ServiceRequest t)
		{
			_serviceRequestDal.Update(t);
		}
	}
}
