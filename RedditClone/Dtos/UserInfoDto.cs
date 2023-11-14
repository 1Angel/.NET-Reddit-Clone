using Microsoft.AspNetCore.Identity;

namespace RedditClone.Dtos
{
    public class UserInfoDto
    {
        public virtual string Id { get; set; }
        public virtual string? UserName { get; set; }
        public virtual string? NormalizedUserName { get; set; }
        public virtual string? Email { get; set; }
    }
}
