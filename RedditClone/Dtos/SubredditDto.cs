using RedditClone.Models;

namespace RedditClone.Dtos
{
    public class SubredditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PostDto> Posts { get; set; }

        public DateTime createdAt { get; set; }

    }
}
