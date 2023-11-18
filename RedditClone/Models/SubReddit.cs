using System.ComponentModel.DataAnnotations;

namespace RedditClone.Models
{
    public class SubReddit
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Post> Posts { get; set; }
        
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public DateTime createdAt { get; set; } = DateTime.Now;

        public DateTime updatedAt { get; set; } = DateTime.Now;
    }
}
