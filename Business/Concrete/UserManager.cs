using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            // ... business codes
            try
            {
                _userDal.Add(user);
                return new SuccessResult();
            }
            catch
            {
                return new ErrorResult();
            }
        }

        public IResult Delete(User user)
        {
            // ... business codes
            try
            {
                _userDal.Delete(user);
                return new SuccessResult();
            }
            catch
            {
                return new ErrorResult();
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            // ... business codes
            try
            {
                return new SuccessDataResult<List<User>>(_userDal.GetAll());
            }
            catch
            {
                return new ErrorDataResult<List<User>>();
            }
        }

        public IDataResult<User> GetById(int id)
        {
            // ... business codes
            try
            {
                return new SuccessDataResult<User>(_userDal.Get(u=> u.Id == id));
            }
            catch
            {
                return new ErrorDataResult<User>();
            }
        }

        public IResult Update(User user)
        {
            // ... business codes
            try
            {
                _userDal.Update(user);
                return new SuccessResult();
            }
            catch
            {
                return new ErrorResult();
            }
        }
    }
}
