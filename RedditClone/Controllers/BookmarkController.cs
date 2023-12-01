using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedditClone.Dtos;
using RedditClone.Models;
using RedditClone.Services;

namespace RedditClone.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[Controller]")]
    public class BookmarkController: ControllerBase
    {
        private readonly IBookmarkService _bookmarkService;
        public BookmarkController(IBookmarkService bookmarkService)
        {
            _bookmarkService = bookmarkService;
        }

        [HttpPost("bookmark/{id}")]
        public async Task<ActionResult<ResponseDto>> Save([FromRoute] int id)
        {
            var UserId = User.Claims.Where(x=>x.Type == "Id").FirstOrDefault()?.Value;

            var save = await _bookmarkService.Save(id, UserId);
            if(save == null)
            {
                return BadRequest(save);
            }
            return Ok(save);
        }
    }
}
