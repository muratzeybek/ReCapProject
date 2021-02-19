using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {


            ICarService carManager = new CarManager(new EfCarDal());
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.Id + "   " + cars.ColorId + " " + cars.ModelYear + "   " + cars.DailyPrice + "TL   " + cars.Description);
                Console.WriteLine("--------------------------------------------------------");
            }

            carManager.Add(new Car { Id=3, BrandId=2, ColorId=3, ModelYear=2020, DailyPrice=150, Description="Audi A4" });

        }
    }
}
