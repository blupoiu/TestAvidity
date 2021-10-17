using System;
using System.Collections.Generic;
using System.Text;

namespace TestAvidity.Utils.Response
{
    /// <summary>
    /// Api response when the call is successful
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiOkResponse<T>: ApiDataResponse<T>
    { 
        public ApiOkResponse(T result)
            : base(result, 200)
        {
        }
    }
}
