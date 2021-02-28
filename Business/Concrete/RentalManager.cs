using Business.Abstract;
using Business.Constants;
using Core.Utilities.NewFolder.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentDal;

        public RentalManager(IRentalDal rentDal)
        {
            _rentDal = rentDal;
        }

        public IResult Add(Rental rental)
        {

            if (rental.ReturnDate != null)
            {
                _rentDal.Add(rental);
                return new SuccessResult(Messages.BrandAdded);
            }
            return new ErrorResult(Messages.RentDeleted);
        }

        public IResult Delete(Rental rental)
        {
            _rentDal.Delete(rental);
            return new SuccessResult(Messages.RentDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentDal.GetAll());
        }

        public IDataResult<Rental> GetById(int RendId)
        {
            return new SuccessDataResult<Rental>(_rentDal.Get(p => p.CarId == RendId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            if (DateTime.Now.Hour==10)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _rentDal.Update(rental);
            return new SuccessResult(Messages.RentUpdated);
        }
    }
}
