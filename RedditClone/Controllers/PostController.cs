using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RedditClone.Dtos;
using RedditClone.Models;
using RedditClone.Services;

namespace RedditClone.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PostController: ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpPost("create/{id}")]
        public async Task<ActionResult<Post>> Create([FromBody] CreatePostDto createPostDto, [FromRoute] int id)
        {
            var post = _mapper.Map<Post>(createPostDto);

            var create = await _postService.Create(post, id);
            return create;
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetById([FromRoute] int id)
        {
            var postid = await _postService.GetById(id);
            if(postid == null)
            {
                return NotFound();
            }
            var post = _mapper.Map<PostDto>(postid);
            return Ok(post);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var postId = await _postService.GetById(id);
            if(postId == null)
            {
                return NotFound();
            }
            _postService.DeleteById(id);
            return Ok();

        }
    }
}
