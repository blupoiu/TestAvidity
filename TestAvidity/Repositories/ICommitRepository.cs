using System.Collections.Generic;
using System.Threading.Tasks;

using TestAvidity.Models;

namespace TestAvidity.Repositories
{
    public interface ICommitRepository
    {
        Task<List<CommitModel>> GetCommits(string url, string accessToken);
    }
}