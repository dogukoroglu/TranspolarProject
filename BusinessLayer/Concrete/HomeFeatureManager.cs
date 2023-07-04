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
	public class HomeFeatureManager : IHomeFeatureService
	{
		IHomeFeatureDal _homeFeatureDal;

		public HomeFeatureManager(IHomeFeatureDal homeFeatureDal)
		{
			_homeFeatureDal = homeFeatureDal;
		}

		public void TAdd(HomeFeature t)
		{
			_homeFeatureDal.Insert(t);
		}

		public void TDelete(HomeFeature t)
		{
			_homeFeatureDal.Delete(t);
		}

		public HomeFeature TGetByID(int id)
		{
			throw new NotImplementedException();
		}

		public List<HomeFeature> TGetListAll()
		{
			return _homeFeatureDal.GetListAll();
		}

		public void TUpdate(HomeFeature t)
		{
			_homeFeatureDal.Update(t);
		}
	}
}
