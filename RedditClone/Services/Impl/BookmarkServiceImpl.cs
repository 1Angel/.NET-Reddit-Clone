using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RedditClone.Data;
using RedditClone.Dtos;
using RedditClone.Models;

namespace RedditClone.Services.Impl
{
    public class BookmarkServiceImpl : IBookmarkService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public BookmarkServiceImpl(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<ResponseDto> Save(int id, string UserId)
        {
            //var user = await _userManager.FindByIdAsync(UserId);
            //var postId = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
            var bookmarkUser = await _context.Bookmarks.FirstOrDefaultAsync(x => x.AppUserId == UserId && x.PostId == id);

            if (bookmarkUser != null)
            {
                return new ResponseDto()
                {
                    Message = "You already save this post",
                    Status = StatusCodes.Status200OK
                };
            }
            else
            {
                BookMark bookMark = new BookMark
                {
                    AppUserId = UserId,
                    PostId = id,
                };

                await _context.Bookmarks.AddAsync(bookMark);
                await _context.SaveChangesAsync();
            }
            return new ResponseDto()
            {
                Message = "Post Bookmark successfully",
                Status = StatusCodes.Status200OK
            };
        }
    }
}
