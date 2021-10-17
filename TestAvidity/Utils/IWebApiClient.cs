using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TestAvidity.Utils
{
    /// <summary>
    /// Performs Web API calls 
    /// </summary>
    public interface IWebApiClient
    {
        /// <summary>
        /// Performs an asynchronous call to get a list of items. 
        /// It will thrown an exception when: web api does not respond or return code is not 200.
        /// </summary>
        /// <typeparam name="T">return type</typeparam>
        /// <param name="url">Web Api Url</param>
        /// <returns></returns>
        Task<List<T>> GetItemListAsync<T>(string url);

        /// <summary>
        /// Performs an asynchronous call to get an item.
        /// It will thrown an exception when: web api does not respond or return code is not 200.
        /// </summary>
        /// <typeparam name="T">return type</typeparam>
        /// <param name="url">Web Api Url</param>
        /// <returns>Parameter to be send to web api</returns>
        Task<T> GetItemAsync<T>(string url);

        void SetToken(string token);
    }
}
