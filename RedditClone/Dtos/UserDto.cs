using Microsoft.AspNetCore.Identity;

namespace RedditClone.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
