using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class NewDatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=NewDatabase;Trusted_Connection=true");
        }

        public DbSet<Car> cars { get; set; }
        public DbSet<Color> colors { get; set; }
        public DbSet<Brand> brands { get; set; }
    }
}
