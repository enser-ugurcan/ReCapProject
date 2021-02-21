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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (NewDatabaseContext databaseContext=new NewDatabaseContext())
            {
                var addedEntity = databaseContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                databaseContext.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (NewDatabaseContext databaseContext = new NewDatabaseContext())
            {
                var deleteEntity = databaseContext.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                databaseContext.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (NewDatabaseContext databaseContext = new NewDatabaseContext())
            {
                return databaseContext.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (NewDatabaseContext databaseContext = new NewDatabaseContext())
            {
                return filter == null
                    ? databaseContext.Set<Color>().ToList()
                    : databaseContext.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color entity)
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
