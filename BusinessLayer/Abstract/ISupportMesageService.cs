using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ISupportMesageService : IGenericService<SupportMessage>
	{
		List<SupportMessage> TGetListSenderMessage(string p);
		List<SupportMessage> TGetListReceiverMessage(string p);
		void TChangeMessageStatus(int id);
	}
}
