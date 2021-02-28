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
    public class EfCarDal : EfEntityRepositoryBase<Car, NewDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (NewDatabaseContext newDatabase = new NewDatabaseContext())
            {
                var result = from car in newDatabase.cars
                             join brand in newDatabase.brands
                             on car.Id equals brand.Id
                             join color in newDatabase.colors
                             on car.Id equals color.Id
                             select new CarDetailDto
                             {
                                 CarName = car.CarName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice
                
                             };
                return result.ToList();

            }
        }
    }
}
