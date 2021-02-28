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

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,NewDatabaseContext>,ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (NewDatabaseContext newDatabase = new NewDatabaseContext())
            {
                var result = from customer in newDatabase.Customers
                             join user in newDatabase.Users
                             on customer.UserId equals user.Id
                             select new CustomerDetailDto
                             {
                                 CompanyName = customer.CompanyName,
                                 Email = user.Email,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Password = user.Password
                             };
                return result.ToList();
            }
        }
    }
}
