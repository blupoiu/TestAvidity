using System;
using System.Collections.Generic;
using System.Text;

namespace TestAvidity.Utils.Response
{
    /// <summary>
    /// Generic api response
    /// </summary>
    public class ApiResponse
    {
        public ApiResponse() { }
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            Succesful = statusCode == 200;
        }

        /// <summary>
        /// False if an unexpected exception was thrown. 
        /// </summary>
        public bool Succesful { get; set; }
        /// <summary>
        /// The same code scheme as in Http protocol. 
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// It contains general error message. It is null when the call was performed without exceptions. 
        /// </summary>
        public string Message { get; set; }
        
        /// <summary>
        /// It contains additional error messages.
        /// </summary>
        public List<string> AdditionalMessages { get; set; }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return "Resource not found";
                case 500:
                    return "An unhandled error occurred";
                default:
                    return null;
            }
        }
    }
}
