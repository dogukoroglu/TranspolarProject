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
	public class QuestionManager : IQuestionService
	{
		IQuestionDal _questionDal;

		public QuestionManager(IQuestionDal questionDal)
		{
			_questionDal = questionDal;
		}

		public void TAdd(Question t)
		{
			_questionDal.Insert(t);
		}

		public void TDelete(Question t)
		{
			_questionDal.Delete(t);
		}

		public Question TGetByID(int id)
		{
			return _questionDal.GetByID(id);
		}

		public List<Question> TGetListAll()
		{
			return _questionDal.GetListAll();
		}

		public void TUpdate(Question t)
		{
			_questionDal.Update(t);
		}
	}
}
