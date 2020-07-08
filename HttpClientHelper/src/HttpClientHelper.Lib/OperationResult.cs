using System;
using System.Collections.Generic;
using System.Text;

namespace HttpClientHelper.Lib
{
    public class OperationResult
    {
        public bool Success
        {
            get
            {
                return this.Exception == null;
            }
        }
        public Exception Exception { get; set; }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Response { get; set; }
    }
}
