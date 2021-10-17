using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using Octokit;
using Octokit.Internal;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using TestAvidity.Models;
using TestAvidity.Repositories;

using ProductHeaderValue = Octokit.ProductHeaderValue;

namespace TestAvidity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; 
        private readonly IConfiguration Configuration;

        private readonly IRepositoriesRepository _repositoriesRepository;
        private readonly IContributorsRepository _contributorsRepository;
        private readonly ICommitRepository _commitRepository;

        public HomeController(ILogger<HomeController> logger,
                              IConfiguration configuration,
                              IRepositoriesRepository repositoriesRepository,
                              IContributorsRepository contributorsRepository,
                              ICommitRepository commitRepository)
        {
            _logger = logger;
            Configuration = configuration;
            _repositoriesRepository = repositoriesRepository;
            _contributorsRepository = contributorsRepository;
            _commitRepository = commitRepository;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            return Challenge(new AuthenticationProperties() { RedirectUri = returnUrl });
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                string accessToken = await HttpContext.GetTokenAsync("access_token");

                var url = Configuration["Links:repository"]; 

                var repositoryData = await _repositoriesRepository.GetRepository(url, accessToken);
                var contributorsData = await _contributorsRepository.GetContributors(repositoryData.contributors_url, accessToken);
                repositoryData.Contributors = contributorsData.OrderByDescending(x => x.Contributions).ToList();
                var commitData = await _commitRepository.GetCommits(repositoryData.commits_url.Replace("{/sha}", ""), accessToken);

                foreach (var cont in repositoryData.Contributors)
                {
                    cont.ContributorCommits = _repositoriesRepository.CalculateData(commitData.Where(x => x.Login == cont.Login).ToList());
                }    

                return View(repositoryData);
            }
            return View();
        }
    }
}
