namespace RedditClone.Models
{
    public class BookMark
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
