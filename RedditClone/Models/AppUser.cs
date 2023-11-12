using Microsoft.AspNetCore.Identity;

namespace RedditClone.Models
{
    public class AppUser: IdentityUser
    {
        public List<SubReddit> Subredits { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Post> Posts { get; set; }
    }
}
