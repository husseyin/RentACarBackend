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
        string defaultPath = @"\Images\noPicture.png";
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

                                 BrandId = b.Id,
                                 BrandName = b.Name,

                                 ColorId = cl.Id,
                                 ColorName = cl.Name,

                                 CarImage = (from ci in context.CarImages
                                             where c.Id == ci.CarId
                                             select new CarImage { Id = ci.Id, CarId = c.Id, Date = ci.Date, Path = (ci.Path == null ? defaultPath : ci.Path) }).ToList(),

                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
