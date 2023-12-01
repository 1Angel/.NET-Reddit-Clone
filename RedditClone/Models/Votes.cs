namespace RedditClone.Models
{
    public class Votes
    {

        public int Id { get; set; }
        public voteType voteType { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }    
    }
}
