using Microsoft.EntityFrameworkCore;
using RedditClone.Models;

namespace RedditClone.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SubReddit> Subreddits { get; set;}
        public DbSet<Post> Posts { get; set;}

        public DbSet<Comment> Comments { get; set;} 
    }
}
