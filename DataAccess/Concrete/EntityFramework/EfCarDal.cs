using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car,bool>>filter=null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in filter==null? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join d in context.Colors on c.ColorId equals d.ColorId
                             select new CarDetailDto { Id = c.Id, BrandName = b.BrandName, ColorName = d.ColorName, DailyPrice = c.DailyPrice };
                return result.ToList();

            }
        }
    }
}
