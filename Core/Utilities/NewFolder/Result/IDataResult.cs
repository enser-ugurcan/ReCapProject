using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.NewFolder.Result
{
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
