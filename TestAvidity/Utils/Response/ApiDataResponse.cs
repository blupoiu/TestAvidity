using System;
using System.Collections.Generic;
using System.Text;

namespace TestAvidity.Utils.Response
{
    /// <summary>
    /// Api response when data has to be send to the client.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiDataResponse<T> : ApiResponse
    {
        public T Result { get; set; }

        public ApiDataResponse()
        { }

        public ApiDataResponse(T result, int statusCode)
            : base(statusCode)
        {
            Result = result;
        }
    }
}
