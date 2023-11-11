using System.ComponentModel.DataAnnotations;

namespace RedditClone.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }

        public DateTime createdAt { get; set; } = DateTime.Now;
    }
}
