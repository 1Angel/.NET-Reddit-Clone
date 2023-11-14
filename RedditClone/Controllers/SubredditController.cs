using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedditClone.Dtos;
using RedditClone.Models;
using RedditClone.Services;

namespace RedditClone.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class SubredditController: ControllerBase
    {
        private readonly ISubRedditService _subRedditService;
        private readonly IMapper mapper;

        public SubredditController(ISubRedditService subRedditService, IMapper mapper)
        {
            _subRedditService = subRedditService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubredditDto>>> Get()
        {
            var data = await _subRedditService.Get();
            if(data == null)
            {
                return NotFound();
            }
            var subreddit = mapper.Map<List<SubredditDto>>(data);
            return subreddit;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SubredditDto>> GetById([FromRoute] int id)
        {
            var subredditId = await _subRedditService.GetById(id);
            if(subredditId == null)
            {
                return NotFound();
            }
            var subReddit = mapper.Map<SubredditDto>(subredditId);
            return Ok(subReddit);
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateSubredditDto createSubredditDto)
        {
            var UserId = User.Claims.Where(a => a.Type == "Id").FirstOrDefault()?.Value;

            var subreddit = mapper.Map<SubReddit>(createSubredditDto);
            var create =  await _subRedditService.Create(subreddit, UserId);
            return CreatedAtAction("GetById", new { id = create.Id }, create);

        }

        [HttpPut("edit/{id}")]
        public async Task<ActionResult> Update([FromBody] UpdateSubredditDto updateSubredditDto, [FromRoute] int id)
        {
            var subredditId = await _subRedditService.GetById(id);
            if(subredditId == null)
            {
                return NotFound();
            }

            var subreddit = mapper.Map<SubReddit>(updateSubredditDto);
            var update = await _subRedditService.Update(subreddit, id);
            return Ok(update);

        }


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var subredditId = await _subRedditService.GetById(id);
            if(subredditId == null)
            {
                return NotFound();
            }
            _subRedditService.Delete(id);
            return Ok();

        }

    }
}
