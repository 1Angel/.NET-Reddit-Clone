using System.ComponentModel.DataAnnotations;

namespace RedditClone.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SubRedditId { get; set; }
        public SubReddit SubReddit { get; set; }
        public List<Comment> Comments { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
