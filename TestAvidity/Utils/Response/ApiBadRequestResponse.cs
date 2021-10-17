using System;
using System.Collections.Generic;
using System.Text;

namespace TestAvidity.Utils.Response
{
    public class ApiBadRequestResponse : ApiResponse
    {
        public ApiBadRequestResponse(string message = null)
        {
            StatusCode = 500;
            Message = message ?? "An unhandled error occurred";
            Succesful = false;
        }
    }
}
