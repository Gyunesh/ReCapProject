using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=150, Description="No smoking", ModelYear=2020 },
                new Car{Id=2, BrandId=1, ColorId=1, DailyPrice=175, Description="Family", ModelYear=2019 },
                new Car{Id=3, BrandId=2, ColorId=2, DailyPrice=200, Description="No smoking", ModelYear=2020 },
                new Car{Id=4, BrandId=2, ColorId=2, DailyPrice=320, Description="Panelvan", ModelYear=2020 },
                new Car{Id=5, BrandId=3, ColorId=2, DailyPrice=400, Description="6 seat", ModelYear=2021 },
                new Car{Id=6, BrandId=4, ColorId=3, DailyPrice=2500, Description="Luxury", ModelYear=2021 }

            };
        
        
        
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.Id == car.Id );
            _cars.Remove(carToDelete);
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

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c=>c.Id == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
            
        }
    }
}
