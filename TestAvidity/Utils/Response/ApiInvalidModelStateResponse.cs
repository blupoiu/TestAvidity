using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TestAvidity.Utils.Response
{
    public class ApiInvalidModelStateResponse: ApiResponse
    {
        public ApiInvalidModelStateResponse(ModelStateDictionary modelState, string message = null)
        {
            StatusCode = 510;
            Message = message ?? "Invalid model state!";
            Succesful = false;
            BuildMessages(modelState);
        }

        private void BuildMessages(ModelStateDictionary modelState)
        {
            AdditionalMessages = new List<string>();
            foreach (var error in modelState)
            {
                AdditionalMessages.Add($"[{error.Key}]: {error.Value}" );
            }
        }
    }
}
