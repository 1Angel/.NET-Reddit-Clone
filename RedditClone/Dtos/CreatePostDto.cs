using System.ComponentModel.DataAnnotations;

namespace RedditClone.Dtos
{
    public class CreatePostDto
    {
        [Required]
        [MaxLength(100)]
        [MinLength(4)]
        public string Title { get; set; }

        [Required]
        [MaxLength(2000)]
        [MinLength(4)]
        public string Description { get; set; }
    }
}
