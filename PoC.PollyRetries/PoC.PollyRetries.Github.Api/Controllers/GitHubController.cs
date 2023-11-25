using Microsoft.AspNetCore.Mvc;
using PoC.PollyRetries.Github.Api.Interfaces;

namespace PoC.PollyRetries.Github.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitHubController : ControllerBase
    {
        private readonly ILogger<GitHubController> _logger;
        private readonly IGithubService _githubService;

        public GitHubController(ILogger<GitHubController> logger, IGithubService githubService)
        {
            _logger = logger;
            _githubService = githubService;
        }

        [HttpGet]
        [Route("User/{userName}")]
        public async Task<string> Get(string userName)
        {
            _logger.LogInformation($"User name is: {userName}");

            return await _githubService.GetUserByName(userName);
        }
    }
}