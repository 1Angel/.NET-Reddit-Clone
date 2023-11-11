using RedditClone.Models;

namespace RedditClone.Services
{
    public interface IPostService
    {
        Task<Post> Create(Post post, int id);
        Task<List<Post>> Get();
        Task<Post> GetById(int id);
        void DeleteById(int id);
    }
}
