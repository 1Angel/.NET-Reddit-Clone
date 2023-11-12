using Microsoft.AspNetCore.Authentication;
using RedditClone.Dtos;

namespace RedditClone.Services
{
    public interface IAuthService
    {
        Task<AuthReponse> Register(CreateUserDto createUserDto);
        Task<AuthReponse> Login(LoginUserDto loginUserDto);
    }
}
