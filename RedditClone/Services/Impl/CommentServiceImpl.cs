using Microsoft.EntityFrameworkCore;
using RedditClone.Data;
using RedditClone.Models;

namespace RedditClone.Services.Impl
{
    public class CommentServiceImpl : ICommentService
    {
        private readonly AppDbContext _context;
        public CommentServiceImpl(AppDbContext context)
        {
            _context = context;
        }

        public AppDbContext Context { get; }

        public async Task<Comment> Create(Comment comment, int id, string UserId)
        {
            var postId = await _context.Posts.FirstOrDefaultAsync(p=>p.Id == id);

            comment.PostId = id;
            comment.AppUserId = UserId;
            var create = await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return create.Entity;
        }

        public async Task<List<Comment>> Get()
        {
            var comment = await _context.Comments.ToListAsync();
            return comment;
        }

        public async Task<Comment> GetById(int id)
        {
            var commentId = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            return commentId;
        }

        public Task<Comment> Update(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
