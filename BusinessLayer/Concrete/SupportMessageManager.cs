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
	public class SupportMessageManager : ISupportMesageService
	{
		ISupportMessageDal _supportMessageDal;

		public SupportMessageManager(ISupportMessageDal supportMessageDal)
		{
			_supportMessageDal = supportMessageDal;
		}

		public void TAdd(SupportMessage t)
		{
			_supportMessageDal.Insert(t);
		}

		public void TDelete(SupportMessage t)
		{
			_supportMessageDal.Delete(t);	
		}

		public SupportMessage TGetByID(int id)
		{
			return _supportMessageDal.GetByID(id);
		}

		public List<SupportMessage> TGetListAll()
		{
			return _supportMessageDal.GetListAll();
		}

		public List<SupportMessage> TGetListReceiverMessage(string p)
		{
			return _supportMessageDal.GetListByFilter(x => x.Receiver == p);
		}

		public List<SupportMessage> TGetListSenderMessage(string p)
		{
			return _supportMessageDal.GetListByFilter(x => x.Sender == p);
		}

		public void TUpdate(SupportMessage t)
		{
			_supportMessageDal.Update(t);
		}
	}
}
