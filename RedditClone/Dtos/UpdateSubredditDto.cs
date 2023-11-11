using System.ComponentModel.DataAnnotations;

namespace RedditClone.Dtos
{
    public class UpdateSubredditDto
    {
        [Required(ErrorMessage = "el campo es obligatorio")]
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "el campo es obligatorio")]
        [MinLength(4)]
        [MaxLength(300)]
        public string Description { get; set; }
    }
}
