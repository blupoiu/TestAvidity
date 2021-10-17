using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using TestAvidity.Models;
using TestAvidity.Utils;

namespace TestAvidity.Repositories
{
    public class RepositoriesRepository : IRepositoriesRepository
    {
        private readonly IWebApiClient _client;

        public RepositoriesRepository(IWebApiClient client)
        {
            _client = client;
        }

        public async Task<Repository> GetRepository(string url, string accessToken)
        {
            _client.SetToken(accessToken);
            return await _client.GetItemAsync<Repository>(url);
        }


        public ContributorCommits CalculateData(List<CommitModel> commit)
        {
            var result = new ContributorCommits();

            result.LastContribution = commit.Max(x => x.Date);
            result.FirstContribution = commit.Min(x => x.Date);
            var weeks = DateUtils.NumberOfWeeks(result.FirstContribution, result.LastContribution);
            result.TotalContributions = commit.Count;
            result.Commits = commit.Sum(x => x.Total);

            result.AvgAdditions = (decimal)commit.Sum(x => x.Additions) / weeks;
            result.AvgDeletions = (decimal)commit.Sum(x => x.Deletions) / weeks;
            result.AvgCommits = (decimal)commit.Sum(x => x.Total) / weeks;
            result.AvgCommits = (decimal)commit.Count / weeks;

            return result;
        }
    }
}
