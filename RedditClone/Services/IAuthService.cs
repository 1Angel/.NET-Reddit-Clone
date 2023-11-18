using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using RedditClone.Dtos;
using RedditClone.Models;

namespace RedditClone.Services
{
    public interface IAuthService
    {
        Task<AuthReponse> Register(CreateUserDto createUserDto);
        Task<AuthReponse> Login(LoginUserDto loginUserDto);

        string GeneratedToken(AppUser user);
    }
}
