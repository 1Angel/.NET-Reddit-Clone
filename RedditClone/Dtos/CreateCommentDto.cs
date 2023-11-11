using System.ComponentModel.DataAnnotations;

namespace RedditClone.Dtos
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        public string Description { get; set; }

    }
}
