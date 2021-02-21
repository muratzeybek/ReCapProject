using DataAccess.Abstract;

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
            // GetCar();
            // AddColorBrand();
            // UpdateColorBrand();
            // DeleteColorBrand();

            GetCarDetails();

        }

        private static void GetCarDetails()
        {
            ICarService carManager = new CarManager(new EfCarDal());
            foreach (var cars in carManager.GetCarDetail())
            {
                Console.WriteLine(cars.CarName + "   " + cars.BrandName + " " + cars.ColorName + "   " + cars.DailyPrice + "TL   ");
                Console.WriteLine("--------------------------------------------------------");
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
            colorManager.Add(new Color { Id = 1, Name = "Beyaz" });
            colorManager.Add(new Color { Id = 2, Name = "Beyaz" });
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
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.Id + "   " + cars.ColorId + " " + cars.ModelYear + "   " + cars.DailyPrice + "TL   " + cars.Description);
                Console.WriteLine("--------------------------------------------------------");
            }
        }
    }
}
