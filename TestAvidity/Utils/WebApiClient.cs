using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;

using Octokit;
using Octokit.Internal;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using ProductHeaderValue = Octokit.ProductHeaderValue;

namespace TestAvidity.Utils
{

    /// <see cref="IWebApiClient"/>
    public class WebApiClient : IWebApiClient
    {
        private HttpClient _client;
        private string _token;

        public WebApiClient(HttpClient client)
        {
            _client = client;
        }

        public void SetToken(string token)
        {
           _token = token;
        }
        public async Task<List<T>> GetItemListAsync<T>(string url)
        {
            return await GetJsonFromResponseAsync<List<T>>(url);
        }

        public async Task<T> GetItemAsync<T>(string url)
        {
            return await GetJsonFromResponseAsync<T>(url);
        }


        private async Task<T> GetJsonFromResponseAsync<T>(string url)
        {
            var contentType = new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json");
          

            _client.DefaultRequestHeaders.Accept.Add(contentType);
            _client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");//Set the User Agent to "request"
            _client.DefaultRequestHeaders.Authorization =new AuthenticationHeaderValue("Bearer", _token);
            var response = _client.GetAsync(url);

            return await ExecuteRequestAndProcessResponse<T>(response);
        }

        protected static async Task<T> ExecuteRequestAndProcessResponse<T>(Task<HttpResponseMessage> task)
        {
            var response = await task;

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"The Call to {response.RequestMessage.RequestUri} failed.  Status code: {response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<T>(json);
            if (apiResponse == null)
            {
                return default;
            }

            return apiResponse;
        }
         
    }
}

