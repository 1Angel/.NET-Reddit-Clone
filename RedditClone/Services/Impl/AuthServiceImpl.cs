using Microsoft.AspNetCore.Identity;
using RedditClone.Dtos;

namespace RedditClone.Services.Impl
{
    public class AuthServiceImpl : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AuthServiceImpl(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<AuthReponse> Login(LoginUserDto loginUserDto)
        {
            var emailExist = await _userManager.FindByEmailAsync(loginUserDto.Email);
            if(emailExist == null)
            {
                return new AuthReponse()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = $"User with the email {loginUserDto.Email} not exists",
                    IsSucceed = false
                };
            }

            var comparePassword = await _userManager.CheckPasswordAsync(emailExist, loginUserDto.Password);
            if (!comparePassword)
            {
                return new AuthReponse()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    IsSucceed = false,
                    Message = "Password dont match"
                };
            }

            return new AuthReponse()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "User loggedin successfully",
                IsSucceed = true
            };
        }

        public async Task<AuthReponse> Register(CreateUserDto createUserDto)
        {
            var userExist = await _userManager.FindByEmailAsync(createUserDto.Email);
            if (userExist != null)
            {
                return new AuthReponse()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = $"User with the email {createUserDto.Email} already exists",
                };
            }

            var user = new IdentityUser()
            {
                UserName = createUserDto.UserName,
                Email = createUserDto.Email,
            };

            var create = await _userManager.CreateAsync(user, createUserDto.Password);
            if(!create.Succeeded) 
            {
                string errorsMessage = "Errors: ";
                foreach(var error in create.Errors)
                {
                    errorsMessage += " " + error.Description;
                }

                return new AuthReponse()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = errorsMessage,
                    IsSucceed = false
                };
            }

            return new AuthReponse()
            {
                StatusCode = StatusCodes.Status200OK,
                IsSucceed = true,
                Message = "User Created Successfully"
            };
        }
    }

          
        
}
