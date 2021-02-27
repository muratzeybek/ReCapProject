using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            // ... business codes
            var result = _rentalDal.Get(r => r.Id == rental.Id);
            if (result.ReturnDate == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult("Araç "+result.ReturnDate+ " tarihine kadar tarafınıza kiralanmıştır.");
            }
            else
            {
                return new ErrorResult(result.ReturnDate+" tarihinden önce kiralayamazsınız.");
            }
        }

        public IResult Delete(Rental rental)
        {
            // ... business codes
            try
            {
                _rentalDal.Delete(rental);
                return new SuccessResult();
            }
            catch
            {
                return new ErrorResult();
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            // ... business codes
            try
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
            }
            catch
            {
                return new ErrorDataResult<List<Rental>>();
            }
        }

        public IDataResult<Rental> GetById(int id)
        {
            // ... business codes
            try
            {
                return new SuccessDataResult<Rental>(_rentalDal.Get(u => u.Id == id));
            }
            catch
            {
                return new ErrorDataResult<Rental>();
            }
        }

        public IResult Update(Rental rental)
        {
            // ... business codes
            try
            {
                _rentalDal.Update(rental);
                return new SuccessResult();
            }
            catch
            {
                return new ErrorResult();
            }
        }
    }
}
