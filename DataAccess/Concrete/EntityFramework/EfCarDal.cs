using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {

            using (NewDatabaseContext databaseContext = new NewDatabaseContext())
            {
                if (entity.Description.Length > 2 && entity.DailyPrice > 0)
                {
                    var addedEntity = databaseContext.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    databaseContext.SaveChanges();
                    Console.WriteLine("Added is succesful");
                }
                else
                {
                    Console.WriteLine("Added is not succesfull");
                }
            }
        }

        public void Delete(Car entity)
        {
            using (NewDatabaseContext databaseContext = new NewDatabaseContext())
            {

                var deletedEntity = databaseContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                databaseContext.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (NewDatabaseContext databaseContext = new NewDatabaseContext())
            {
                return databaseContext.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (NewDatabaseContext databaseContext = new NewDatabaseContext())
            {
                return filter == null
                    ? databaseContext.Set<Car>().ToList()
                    : databaseContext.Set<Car>().Where(filter).ToList();
                
            }  
        }

        public void Update(Car entity)
        {
            using (NewDatabaseContext databaseContext = new NewDatabaseContext())
            {

                var updatedEntity = databaseContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                databaseContext.SaveChanges();
            }
        }
    }
}
