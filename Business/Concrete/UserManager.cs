using Business.Abstract;
using Business.Constants;
using Core.Utilities.NewFolder.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User rental)
        {
            _userDal.Add(rental);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User rental)
        {
            _userDal.Delete(rental);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int RendId)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.Id == RendId));
        }

        public IResult Update(User rental)
        {
            _userDal.Update(rental);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
