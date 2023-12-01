using RedditClone.Dtos;
using RedditClone.Models;

namespace RedditClone.Services
{
    public interface IBookmarkService
    {
        Task<ResponseDto> Save(int id, string UserId);
    }
}
