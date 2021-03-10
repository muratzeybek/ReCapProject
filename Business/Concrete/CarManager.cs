using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            ValidationTool.Validate(new CarValidator(), car);
            _carDal.Add(car);
            return new Result(true, Messages.DataAdded);
        }

        public IResult Delete(Car car)
        {
            return new ErrorResult("No command.");
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.DataList);
        }

        public IDataResult<List<Car>> GetById(int id)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(p => p.Id == id), true, Messages.AllDataList);
        }


        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.DataUpdated);
        }
    }
}
