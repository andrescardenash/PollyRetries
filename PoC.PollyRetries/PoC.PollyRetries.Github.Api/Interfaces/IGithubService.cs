namespace PoC.PollyRetries.Github.Api.Interfaces
{
    public interface IGithubService
    {
        Task<string> GetUserByName(string userName);
    }
}