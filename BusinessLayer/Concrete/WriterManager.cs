﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;//ekledim
using DataAccessLayer.EntityFramework;

namespace BusinessLayer.Concrete
{
	public class WriterManager : IWriterServices
	{
		IWriterDal _writerdal;
     

        public WriterManager(IWriterDal writerdal)
		{
			_writerdal = writerdal;
		}

        public List<Writer> GetList()
        {
            throw new NotImplementedException();
        }
     

        public List<Writer> GetWriterById(int id)
        {
            return _writerdal.GetListAll(x=>x.WriterID== id);
        }

        public void TAdd(Writer t)
        {
            _writerdal.Insert(t);
        }

        public void TDelete(Writer t)
        {
            throw new NotImplementedException();
        }

        public Writer TGetById(int id)
        {
           return  _writerdal.GetByID(id);
        }

        public void TUpdate(Writer t)
        {
             _writerdal.Update(t);
        }

    
	}
}
