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
	public class FeaturedServiceManager : IFeaturedServiceService
	{
		IFeaturedServiceDal _featuredServiceDal;

		public FeaturedServiceManager(IFeaturedServiceDal featuredServiceDal)
		{
			_featuredServiceDal = featuredServiceDal;
		}

		public void TAdd(FeaturedService t)
		{
			_featuredServiceDal.Insert(t);
		}

		public void TDelete(FeaturedService t)
		{
			_featuredServiceDal.Delete(t);
		}

		public FeaturedService TGetByID(int id)
		{
			throw new NotImplementedException();
		}

		public List<FeaturedService> TGetListAll()
		{
			return _featuredServiceDal.GetListAll();
		}

		public void TUpdate(FeaturedService t)
		{
			_featuredServiceDal.Update(t);
		}
	}
}
