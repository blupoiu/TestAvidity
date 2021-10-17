using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TestAvidity.Models;
using TestAvidity.Utils;

namespace TestAvidity.Repositories
{
    public class CommitRepository : ICommitRepository
    {

        private readonly IWebApiClient _client;

        public CommitRepository(IWebApiClient client)
        {
            _client = client;
        }

        public async Task<List<CommitModel>> GetCommits(string url, string accessToken)
        {
            _client.SetToken(accessToken); 
            var commits = await _client.GetItemListAsync<Commit>(url);
            var result = new List<CommitModel>();
            foreach (var commit in commits)
            {
                var info = GetCommitInfo(commit.Url,accessToken).Result;
                result.Add(new CommitModel
                {
                    Login = info.Author.Login,
                    Date = info.Commit.Author.Date,
                    Additions = info.Stats.Additions,
                    Deletions = info.Stats.Deletions,
                    Total = info.Stats.Total
                }); ;
            }
            return result;
        }
        private async Task<CommitInfo> GetCommitInfo(string url, string accessToken)
        {
            _client.SetToken(accessToken);
            return await _client.GetItemAsync<CommitInfo>(url);
        }
    }
}
