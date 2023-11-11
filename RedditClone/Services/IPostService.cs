using RedditClone.Models;

namespace RedditClone.Services
{
    public interface IPostService
    {
        Task<Post> Create(Post post, int id);
        Task<Post> Get();
        Task<Post> GetById(int id);
    }
}
