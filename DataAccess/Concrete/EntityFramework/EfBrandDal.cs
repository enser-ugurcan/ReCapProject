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
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (NewDatabaseContext databaseContext=new NewDatabaseContext())
            {
                var addedEntity = databaseContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                databaseContext.SaveChanges();

            }
        }

        public void Delete(Brand entity)
        {
            using (NewDatabaseContext databaseContext = new NewDatabaseContext())
            {
                var deletedEntity = databaseContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                databaseContext.SaveChanges();

            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (NewDatabaseContext databaseContext = new NewDatabaseContext())
            {
                return databaseContext.Set<Brand>().SingleOrDefault(filter);

            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (NewDatabaseContext databaseContext = new NewDatabaseContext())
            {
                return filter == null
                    ? databaseContext.Set<Brand>().ToList()
                    : databaseContext.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand entity)
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
