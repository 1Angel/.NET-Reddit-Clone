using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RedditClone.Data;
using RedditClone.Dtos;
using RedditClone.Models;

namespace RedditClone.Services.Impl
{
    public class PostServiceImpl : IPostService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public PostServiceImpl(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<Post> Create(Post post, int id, string UserId)
        {
            var SubRedditId = await _context.Subreddits.FirstOrDefaultAsync(x => x.Id == id);

            post.AppUserId = UserId;
            post.SubRedditId = id;
            var create = await _context.Posts.AddAsync(post);  
            await _context.SaveChangesAsync();
            return create.Entity;
        }

        public async Task<ResponseDto> DeleteById(int id, string userId)
        {
            var postId = await _context.Posts.FirstOrDefaultAsync(x=>x.Id == id);

            var User  = await _userManager.FindByIdAsync(userId);


            if(postId.AppUser.Id != User.Id)
            {
                return new ResponseDto()
                {
                    Message = "You are not the creator of the post",
                    Status = StatusCodes.Status403Forbidden
                };
            }

            if(postId !=null)
            {
                _context.Posts.Remove(postId);
                await _context.SaveChangesAsync();
            }

            return new ResponseDto()
            {
                Message = "Post Deleted",
                Status = StatusCodes.Status200OK
            };
        }

        public async Task<List<Post>> Get()
        {
            var post = await _context.Posts.ToListAsync();
            return post;
        }

        public async Task<Post> GetById(int id)
        {
            var postId = await _context.Posts.Include(x=>x.AppUser).Include(x=>x.Comments).ThenInclude(x=>x.AppUser).FirstOrDefaultAsync(x=>x.Id == id);
            return postId;
        }


    }
}
