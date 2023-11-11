using Microsoft.EntityFrameworkCore;
using RedditClone.Data;
using RedditClone.Models;

namespace RedditClone.Services.Impl
{
    public class PostServiceImpl : IPostService
    {
        private readonly AppDbContext _context;
        public PostServiceImpl(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Post> Create(Post post, int id)
        {
            var SubRedditId = await _context.Subreddits.FirstOrDefaultAsync(x => x.Id == id);

            post.SubRedditId = id;
            var create = await _context.Posts.AddAsync(post);  
            await _context.SaveChangesAsync();
            return create.Entity;
        }

        public async void DeleteById(int id)
        {
            var postId = await _context.Posts.FirstOrDefaultAsync(x=>x.Id == id);
            if(postId !=null)
            {
                _context.Posts.Remove(postId);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Post>> Get()
        {
            var post = await _context.Posts.ToListAsync();
            return post;
        }

        public async Task<Post> GetById(int id)
        {
            var postId = await _context.Posts.FirstOrDefaultAsync(x=>x.Id == id);
            return postId;
        }
    }
}
