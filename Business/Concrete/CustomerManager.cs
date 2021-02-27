using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            // ... business codes
            try
            {
                _customerDal.Add(customer);
                return new SuccessResult();
            }
            catch
            {
                return new ErrorResult();
            }
        }

        public IResult Delete(Customer customer)
        {
            // ... business codes
            try
            {
                _customerDal.Delete(customer);
                return new SuccessResult();
            }
            catch
            {
                return new ErrorResult();
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            // ... business codes
            try
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
            }
            catch
            {
                return new ErrorDataResult<List<Customer>>();
            }
        }

        public IDataResult<Customer> GetById(int id)
        {
            // ... business codes
            try
            {
                return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id));
            }
            catch
            {
                return new ErrorDataResult<Customer>();
            }
        }

        public IResult Update(Customer customer)
        {
            // ... business codes
            try
            {
                _customerDal.Update(customer);
                return new SuccessResult();
            }
            catch
            {
                return new ErrorResult();
            }
        }
    }
}
