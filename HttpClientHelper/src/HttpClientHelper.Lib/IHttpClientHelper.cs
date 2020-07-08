using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientHelper.Lib
{
    public interface IHttpClientHelper
    {
        Task<OperationResult<T>> Get<T>(string path);       

        Task<OperationResult<T>> Get<T>(string path, string authenticationType, string key);

        Task<OperationResult<T>> Post<T>(string path, T body);
    }
}
