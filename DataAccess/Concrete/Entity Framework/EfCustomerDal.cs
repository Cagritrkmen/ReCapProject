using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using DataAccess.Concrete.Entity_Framework;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from cu in context.Customers
                             join u in context.Users
                             on cu.UserId equals u.Id
                             select new CustomerDetailDto
                             {
                                 Id = cu.Id,
                                 CompanyName = cu.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                               

                             };

                return result.ToList();
            }
        }

        public CustomerDetailDto GetCustomerDetailsById(int customerId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from cu in context.Customers
                             join u in context.Users
                             on cu.UserId equals u.Id
                             where cu.Id == customerId
                             select new CustomerDetailDto
                             {
                                 Id = cu.Id,
                                 CompanyName = cu.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 

                             };

                return result.SingleOrDefault();
            }
        }

        public CustomerDetailDto GetCustomerDetailsByUserId(int userId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from cu in context.Customers
                             join u in context.Users
                             on cu.UserId equals u.Id
                             where cu.UserId == userId
                             select new CustomerDetailDto
                             {
                                 Id = cu.Id,
                                 CompanyName = cu.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 

                             };

                return result.SingleOrDefault();
            }
        }
    }
}
