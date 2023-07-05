﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class SocialMediaManager : ISocialMediaService
	{
		ISocialMediaDal _socialMediaDal;

		public SocialMediaManager(ISocialMediaDal socialMediaDal)
		{
			_socialMediaDal = socialMediaDal;
		}

		public void TAdd(SocialMedia t)
		{
			_socialMediaDal.Insert(t);
		}

		public void TDelete(SocialMedia t)
		{
			_socialMediaDal.Delete(t);
		}

		public SocialMedia TGetByID(int id)
		{
			throw new NotImplementedException();
		}

		public List<SocialMedia> TGetListAll()
		{
			return _socialMediaDal.GetListAll();
		}

		public void TUpdate(SocialMedia t)
		{
			_socialMediaDal.Update(t);
		}
	}
}
