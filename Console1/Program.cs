using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace Console1
{
    class Program
    {
        static void Main(string[] args)
        {
            carTest();
            //MarkaEkleme();
            //RenkSilme();

        }

        private static void RenkSilme()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Delete(new Color { ColorId = 6 });
        }

        private static void MarkaEkleme()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandId = 11, BrandName = "Lancia" });
        }

        private static void carTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.Id+" "+car.BrandName+" "+car.ColorName+" "+car.DailyPrice);

            }
        }
    }
}
