using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RedditClone.Data;
using RedditClone.Dtos;
using RedditClone.Models;

namespace RedditClone.Services.Impl
{
    public class BookmarkService : IBookmarkService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public BookmarkService(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<ResponseDto> Save(int id, string UserId)
        {

            var user = await _userManager.FindByIdAsync(UserId);
            var postdb = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
            
            var bookmarkPostId = await _context.Bookmarks.Where(x=>x.PostId == postdb.Id).FirstOrDefaultAsync();
            if (bookmarkPostId == null)
            {
                BookMark bookMark = new BookMark();
                bookMark.PostId = id;
                bookMark.AppUserId = UserId;

                var save = await _context.Bookmarks.AddAsync(bookMark);
                await _context.SaveChangesAsync();
            }
            else if (user.Id == bookmarkPostId.AppUserId)
            {
                return new ResponseDto()
                {
                    Message = "Post Already saved",
                    Status = StatusCodes.Status400BadRequest
                };
            }
         
            return new ResponseDto()
            {
                Message = "Post Saved",
                Status = StatusCodes.Status200OK
            };
        }
    }
}
