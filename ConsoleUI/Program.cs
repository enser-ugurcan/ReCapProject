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
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //userManager.Add(new User { Id = 7, FirstName = "Beyaz", LastName = "Ateşçakmak", Email = "etescakmak@hotmil.com", Password = "123456" });
            // customerManager.Add(new Customer { Id = 6, UserId = 4, CompanyName = "EUA" });
            //rentalManager.Delete(new Rental { Id = 6, CarId = 1, CustomerId = 3, RentDate = DateTime.Now, ReturnDate =new DateTime(2021,02,25,22,20,10) });
            //Console.WriteLine(rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = new DateTime(2021, 2, 25) }).Message);
            var result = rentalManager.GetAll();
            if (result.Success)
            {
                Console.WriteLine(result.Success);
                foreach (var rentall in result.Data)
                {
                    Console.WriteLine(rentall.Id);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            


        }
    }
}

