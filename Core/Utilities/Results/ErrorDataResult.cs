using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    class ErrorDataResult<T> : Result, IDataResult<T>
    {
        public ErrorDataResult(T data) : base(false)
        {
            Data = data;
        }

        public ErrorDataResult(T data, string message) : base(false, message)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
