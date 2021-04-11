using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 CarName = b.Name + ' ' + cl.Name,
                                 ModelYear = c.ModelYear,
                                 BrandName = b.Name,
                                 ColorName = cl.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
