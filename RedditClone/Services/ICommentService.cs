﻿using RedditClone.Models;

namespace RedditClone.Services
{
    public interface ICommentService
    {
        Task<Comment> Create(Comment comment, int id, string UserId);
        Task<Comment> Update(Comment comment);
        Task<Comment> GetById(int id);
        Task<List<Comment>> Get();
    }
}
