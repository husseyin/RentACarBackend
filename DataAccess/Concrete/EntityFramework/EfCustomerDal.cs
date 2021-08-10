using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentCarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<CustomerDetailDto , bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = c.Id,
                                 UserId = u.Id,
                                 UserName = u.FirstName + " " + u.LastName,
                                 Email = u.Email,
                                 CompanyName = c.CompanyName
                             };                
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }            
        }
    }
}
