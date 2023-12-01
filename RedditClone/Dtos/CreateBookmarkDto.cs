using RedditClone.Models;

namespace RedditClone.Dtos
{
    public class CreateBookmarkDto
    {
        public int Id { get; set; }
        public AppUser AppUser { get; set; }
        public Post Post { get; set; }
    }
}
