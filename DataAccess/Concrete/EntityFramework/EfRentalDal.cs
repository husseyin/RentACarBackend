using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,RentCarContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join cu in context.Customers
                             on r.CustomerId equals cu.Id
                             join b in context.Brands 
                             on c.BrandId equals b.Id
                             join u in context.Users
                             on cu.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 RentalId=r.Id   ,
                                 CarName=b.Name,
                                 CustomerName=u.FirstName+" "+u.LastName,
                                 RentDate=r.RentDate.Date,
                                 ReturnDate=r.ReturnDate
                                 
                             };
                return result.ToList();
            }
        }
    }
}
