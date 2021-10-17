using System.Collections.Generic;
using System.Threading.Tasks;

using TestAvidity.Models;

namespace TestAvidity.Repositories
{
    public interface IContributorsRepository
    {
        Task<Commit> GetContributorDates(string url, string accessToken);
        Task<ContributorInfo> GetContributorInfo(string url, string accessToken);
        Task<List<ContributorModel>> GetContributors(string url, string accessToken);
    }
}