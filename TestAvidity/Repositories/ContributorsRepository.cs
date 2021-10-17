using Newtonsoft.Json;

using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using TestAvidity.Models;
using TestAvidity.Utils;

namespace TestAvidity.Repositories
{
    public class ContributorsRepository : IContributorsRepository
    {
        private readonly IWebApiClient _client;

        public ContributorsRepository(IWebApiClient client)
        {
            _client = client;
        }

        public async Task<List<ContributorModel>> GetContributors(string url, string accessToken)
        {
            _client.SetToken(accessToken);
             
            var contributors = await _client.GetItemListAsync<ContributorModel>(url);
            foreach (var contributor in contributors)
            {
                var info = GetContributorInfo(contributor.Url, accessToken).Result;
                contributor.Name = info != null ? info.Name : "N/A";
            }
            return contributors;
        }


        public async Task<ContributorInfo> GetContributorInfo(string url, string accessToken)
        {
            _client.SetToken(accessToken);
            return await _client.GetItemAsync<ContributorInfo>(url);
        }
        public async Task<Commit> GetContributorDates(string url, string accessToken)
        {
            _client.SetToken(accessToken);

            return await _client.GetItemAsync<Commit>(url);
        }
    }
}
