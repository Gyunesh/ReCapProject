using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentDetailDto> GetRentDetails(Expression<Func<Rental, bool>> filter = null)   
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from rnt in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join cr in context.Cars on rnt.CarId equals cr.Id
                             join col in context.Colors on cr.ColorId equals col.ColorId
                             join brd in context.Brands on cr.BrandId equals brd.BrandId
                             join cus in context.Customers on rnt.CustomerId equals cus.UserId
                             join usr in context.Users on cus.UserId equals usr.Id
                             select new RentDetailDto
                             {
                                 Id = rnt.Id,
                                 FirstName = usr.FirstName,
                                 LastName = usr.LastName,
                                 CompanyName = cus.CompanyName,
                                 BrandName = brd.BrandName,
                                 ColorName = col.ColorName,
                                 DailyPrice = cr.DailyPrice,
                                 RentDate = rnt.RentDate,
                                 ReturnDate = rnt.ReturnDate

                             };
                return result.ToList();






            }





        }

    }
}
