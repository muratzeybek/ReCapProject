using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { Id = 1, BrandId = 1, ColorId=1, ModelYear=2018, DailyPrice=150, Description ="Renault Clio Symbol" },
                new Car { Id = 2, BrandId = 2, ColorId=1, ModelYear=2020, DailyPrice=250, Description ="Wolkswagen Golf" },
                new Car { Id = 3, BrandId = 2, ColorId=2, ModelYear=2021, DailyPrice=500, Description ="Wolkswagen Passat" },
                new Car { Id = 4, BrandId = 3, ColorId=2, ModelYear=2020, DailyPrice=250, Description ="Peugeot 206" },
                new Car { Id = 5, BrandId = 3, ColorId=3, ModelYear=2021, DailyPrice=600, Description ="Peugeot 406" }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDeleted = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDeleted);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(p => p.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdated = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdated.BrandId = car.BrandId;
            carToUpdated.ColorId = car.ColorId;
            carToUpdated.ModelYear = car.ModelYear;
            carToUpdated.DailyPrice = car.DailyPrice;
            carToUpdated.Description = car.Description;
        }
    }
}
