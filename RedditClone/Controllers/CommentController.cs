using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RedditClone.Dtos;
using RedditClone.Models;
using RedditClone.Services;

namespace RedditClone.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CommentController: ControllerBase
    {
        private readonly ICommentService   _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;


        }

        [HttpPost("create/{id}/comments")]
        public async Task<ActionResult<Comment>> Create([FromBody] CreateCommentDto createCommentDto, [FromRoute] int id)
        {
            var comment = _mapper.Map<Comment>(createCommentDto);
            var create = await _commentService.Create(comment, id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDto>> GetById([FromRoute] int id)
        {
           var commentId = await _commentService.GetById(id);
            if(commentId == null)
            {
                return NotFound();
            }

            var comment = _mapper.Map<CommentDto>(commentId);
            return comment;
        }
    }
}
