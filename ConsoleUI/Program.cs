using DataAccess.Abstract;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // GetCar();
            // AddColorBrand();
            // UpdateColorBrand();
            // DeleteColorBrand();

            // GetCarDetails();

            IRentalService rentalService = new RentalManager(new EfRentalDal());
            var result = rentalService.Add(new Rental { Id = 2, CarId = 1, CustomerId = 1, RentalDate = new DateTime(2021, 02, 27), ReturnDate = new DateTime(2021, 03, 01) });

            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        // ************************************************************
        private static void GetCarDetails()
        {
            ICarService carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var cars in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(cars.CarName + "   " + cars.BrandName + " " + cars.ColorName + "   " + cars.DailyPrice + "TL   ");
                    Console.WriteLine("--------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void DeleteColorBrand()
        {
            // Color Delete Testing
            IColorService colorManager = new ColorManager(new EfColorDal());
            colorManager.Delete(new Color { Id = 2, Name = "Kırmızı" });
            Console.WriteLine("Renk silindi...");

            // Brand Delete Testing
            IBrandService brandManager = new BrandManager(new EfBrandDal());
            brandManager.Delete(new Brand { Id = 2, Name = "306" });
            Console.WriteLine("Model silindi...");
        }

        private static void UpdateColorBrand()
        {
            // Color Update Testing
            IColorService colorManager = new ColorManager(new EfColorDal());
            colorManager.Update(new Color { Id = 2, Name = "Kırmızı" });
            Console.WriteLine("Renk güncellendi...");

            // Brand Update Testing
            IBrandService brandManager = new BrandManager(new EfBrandDal());
            brandManager.Update(new Brand { Id = 2, Name = "306" });
            Console.WriteLine("Model güncellendi...");
        }

        private static void AddColorBrand()
        {
            // Color Add Testing
            IColorService colorManager = new ColorManager(new EfColorDal());


            colorManager.Add(new Color { Id = 3, Name = "Siyah" });
            colorManager.Add(new Color { Id = 4, Name = "Turkuaz" });
            Console.WriteLine("Renk kaydedildi...");

            // Brand Add Testing
            IBrandService brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { Id = 1, Name = "Partner" });
            brandManager.Add(new Brand { Id = 2, Name = "Partner" });
            Console.WriteLine("Model kaydedildi...");
        }

        private static void GetCar()
        {
            ICarService carManager = new CarManager(new EfCarDal());

            IDataResult<List<Car>> carData = carManager.GetAll();

            if (carData.Data == null)
            {
                Console.WriteLine("NULL DEĞER DÖNDÜ");
            }
            else
            {
                foreach (var cars in carData.Data)
                {
                    Console.WriteLine(cars.ModelYear + "   " + cars.DailyPrice + "TL   " + cars.Description);
                    Console.WriteLine("--------------------------------------------------------");
                }
            }
            Console.WriteLine(carData.Message);
        }
    }
}
