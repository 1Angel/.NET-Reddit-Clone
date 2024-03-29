﻿using RedditClone.Models;

namespace RedditClone.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<CommentDto> Comments { get; set; }
        public UserDto AppUser { get; set; }
        public DateTime CreatedDate { get; set; } 
    }
}
