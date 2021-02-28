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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, NewDatabaseContext>, IRentalDal
    {
       
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (NewDatabaseContext newDatabase = new NewDatabaseContext())
            {
                var result = from rental in newDatabase.Rentals
                             join car in newDatabase.cars
                             on rental.CarId equals car.Id
                             join customer in newDatabase.Customers
                             on rental.CustomerId equals customer.Id
                             select new RentalDetailDto
                             {
                                 Id = rental.Id,
                                 CarId = car.Id,
                                 CompanyName = customer.CompanyName,
                                 CustomerId = customer.Id,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();

            }
        }
    }
}
