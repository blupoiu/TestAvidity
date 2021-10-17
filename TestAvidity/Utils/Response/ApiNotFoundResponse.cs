using System;
using System.Collections.Generic;
using System.Text;

namespace TestAvidity.Utils.Response
{
    public class ApiNotFoundResponse : ApiResponse
    {
        public ApiNotFoundResponse(string message = null)
        {
            StatusCode = 404;
            Message = message ?? "Object not found!";
            Succesful = false;
        }
    }
}
