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
            //carTest();
            //MarkaEkleme();
            //RenkSilme();
            //yenikullanici();
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer {CompanyName="Lamba turizm"});

        }

        private static void NewMethod()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { Id = 6, FirstName = "Gamze", LastName = "Bir", Email = "gamzebir@hotmail.com", Password = "123456" });
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

            var result = carManager.GetCarDetails();

            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Id+" "+car.BrandName+" "+car.ColorName+" "+car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
    }
}
