using System.ComponentModel.DataAnnotations;

namespace RedditClone.Dtos
{
    public class CreateUserDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [MinLength(4)]
        [MaxLength(30)]
        public string Email {  get; set; }
        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
    }
}
