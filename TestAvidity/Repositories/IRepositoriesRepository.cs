using System.Collections.Generic;
using System.Threading.Tasks;

using TestAvidity.Models;

namespace TestAvidity.Repositories
{
    public interface IRepositoriesRepository
    {
        ContributorCommits CalculateData(List<CommitModel> commit);
        Task<Repository> GetRepository(string url, string accessToken);
    }
}