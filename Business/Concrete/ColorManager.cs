using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new Result(true, Messages.DataAdded);
        }

        public IResult Delete(Color color)
        {
            // SİLMEDİM   _colorDal.Delete(color);
            return new ErrorResult("No Delete Operation");
        }

        public IDataResult <List<Color>> GetAll()
        {
            return new DataResult<List<Color>>(_colorDal.GetAll(),true,Messages.AllDataList);
        }

        public IDataResult <Color> GetById(int id)
        {
            return new DataResult<Color>(_colorDal.Get(c => c.Id == id),true, Messages.DataList);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.DataUpdated);
        }
    }
}
