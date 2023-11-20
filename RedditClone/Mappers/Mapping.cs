using AutoMapper;
using RedditClone.Dtos;
using RedditClone.Models;

namespace RedditClone.Mappers
{
    public class Mapping: Profile
    {
        public Mapping() 
        {

            //subreddit
            CreateMap<CreateSubredditDto, SubReddit>();

            CreateMap<SubReddit, SubredditDto>();

            CreateMap<UpdateSubredditDto, SubReddit>();


            //post
            CreateMap<CreatePostDto, Post>();

            CreateMap<Post, PostDto>();


            //comments
            CreateMap<CreateCommentDto, Comment>();

            CreateMap<Comment, CommentDto>();
        

            //identity
            CreateMap<AppUser, UserDto>();
        }
    }
}
