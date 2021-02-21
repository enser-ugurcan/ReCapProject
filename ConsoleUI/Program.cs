using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car = new Car
            {
                Id = 2,
                BrandId=2,
                ColorId=2,
                DailyPrice=200,
                ModelYear=2021,
                Description="TDI 2.0 Motor"
            };
            carManager.Add(car);

            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.Description);
            }


            
        }
    }
}
