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
	public class Question2Manager : IQuestion2Service
	{
		IQuestion2Dal _question2Dal;

		public Question2Manager(IQuestion2Dal question2Dal)
		{
			_question2Dal = question2Dal;
		}

		public void TAdd(Question2 t)
		{
			_question2Dal.Insert(t);	
		}

		public void TDelete(Question2 t)
		{
			_question2Dal.Delete(t);
		}

		public Question2 TGetByID(int id)
		{
			return _question2Dal.GetByID(id);	
		}

		public List<Question2> TGetListAll()
		{
			return _question2Dal.GetListAll();
		}

		public void TUpdate(Question2 t)
		{
			_question2Dal.Update(t);
		}
	}
}
