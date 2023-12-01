using RedditClone.Dtos;
using RedditClone.Models;

namespace RedditClone.Services
{
    public interface IPostService
    {
        Task<Post> Create(Post post, int id, string UserId);
        Task<List<Post>> Get();
        Task<Post> GetById(int id);
        Task<ResponseDto> DeleteById(int id, string userId);
        
    }
}
