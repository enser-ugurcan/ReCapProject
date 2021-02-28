using Core.Utilities.NewFolder.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int RendId);
        IResult Add(User rental);
        IResult Delete(User rental);
        IResult Update(User rental);
    }
}
