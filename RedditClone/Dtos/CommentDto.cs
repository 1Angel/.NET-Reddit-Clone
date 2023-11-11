using RedditClone.Models;

namespace RedditClone.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
    }
}
