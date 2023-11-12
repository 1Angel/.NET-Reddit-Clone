using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedditClone.Dtos;
using RedditClone.Services;
using System.Security.Claims;

namespace RedditClone.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthReponse>> Register([FromBody] CreateUserDto createUserDto)
        {
            var register = await _authService.Register(createUserDto);
            if (register.IsSucceed)
            {
                return Ok(register);
            }
            return BadRequest(register);
        }



        [HttpPost("login")]
        public async Task<ActionResult<AuthReponse>> Login([FromBody] LoginUserDto loginUserDto)
        {
            var loginUser = await _authService.Login(loginUserDto);
            if (loginUser.IsSucceed)
            {
                return Ok(loginUser);
            }
            return BadRequest(loginUser);
        }

        [Authorize]
        [HttpGet("test")]
        public string HOla()
        {
            var user = User.Claims.Where(a=>a.Type =="Id").FirstOrDefault()?.Value;

            return user;
        }
    }
}
