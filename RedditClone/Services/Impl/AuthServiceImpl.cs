using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using RedditClone.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RedditClone.Services.Impl
{
    public class AuthServiceImpl : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        public AuthServiceImpl(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public string GeneratedToken(IdentityUser user)
        {

            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:JwtSecretKey").Value);

            var jwtHandler = new JwtSecurityTokenHandler();

            var claim = new List<Claim>()
            {
                new Claim("Id", user.Id),
                new Claim("UserName", user.UserName),
                new Claim("Email", user.Email)
            };

            var expire = DateTime.Now.AddMonths(1);
            var SignalCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claim, expires: expire, signingCredentials: SignalCredentials);
            
            var token = jwtHandler.WriteToken(securityToken);
            return token;
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

            var token = GeneratedToken(emailExist);
            return new AuthReponse()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "User loggedin successfully",
                IsSucceed = true,
                Token = token
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

            var token = GeneratedToken(user);

            return new AuthReponse()
            {
                StatusCode = StatusCodes.Status200OK,
                IsSucceed = true,
                Message = "User Created Successfully",
                Token = token
            };
        }
    }

          
        
}
