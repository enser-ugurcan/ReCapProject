using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            carManager.GetAll();
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Id + " numaralı aracın modeli : " +item.ModelYear);
            }
            Console.WriteLine("--------------------------------------");
            CarManager carManager1 = new CarManager(new InMemoryCarDal());
            carManager1.GetById(5);
            foreach (var item in carManager.GetById(5))
            {
                Console.WriteLine(item.Id +" numaları ıd ye sahip aracın günlük kullanım ücreti " + item.DailyPrice + " Tl dir");
            }
        }
    }
}
