using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new Result(true, "Data added.");
        }

        public IResult Delete(Brand brand)
        {
            // SİLMEDİM  _brandDal.Delete(brand);
            return new ErrorResult("Deleting error!");
        }

        public IDataResult <List<Brand>> GetAll()
        {
            return new DataResult<List<Brand>>(_brandDal.GetAll(),true,"Listing all brands.");
        }

        public IDataResult <Brand> GetByBrandId(int id)
        {
            return new SuccessDataResult <Brand>(_brandDal.Get(b => b.Id == id),id+" id brand is listing.");
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new Result(true, "Data updated.");
        }
    }
}
