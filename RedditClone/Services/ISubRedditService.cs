using RedditClone.Models;

namespace RedditClone.Services
{
    public interface ISubRedditService
    {
        Task<SubReddit> Create(SubReddit subreddit, string UserId);
        Task<SubReddit> Update(SubReddit subreddit, int id);
        void Delete(int id);
        Task<List<SubReddit>> Get();
        Task<SubReddit> GetById(int id);
    }
}
