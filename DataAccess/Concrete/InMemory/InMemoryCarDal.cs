using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2020,DailyPrice=250,CarName="1.5 Motor"},
                new Car{Id=2,BrandId=2,ColorId=2,ModelYear=2019,DailyPrice=350,CarName="1.6 Motor"},
                new Car{Id=3,BrandId=3,ColorId=3,ModelYear=2018,DailyPrice=200,CarName="1.8 Motor"},
                new Car{Id=4,BrandId=4,ColorId=5,ModelYear=2017,DailyPrice=280,CarName="2.0 Motor"},
                new Car{Id=5,BrandId=5,ColorId=5,ModelYear=2021,DailyPrice=450,CarName="3.0 Motor"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int CarId)
        {
            return _cars.Where(p => p.Id == CarId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public IList<Car> GetList(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
           Car carToUpdate= _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.CarName = car.CarName;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
