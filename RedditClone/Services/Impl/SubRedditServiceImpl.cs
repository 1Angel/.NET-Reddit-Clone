﻿using Microsoft.EntityFrameworkCore;
using RedditClone.Data;
using RedditClone.Models;

namespace RedditClone.Services.Impl
{
    public class SubRedditServiceImpl : ISubRedditService
    {
        public readonly AppDbContext _context;

        public SubRedditServiceImpl(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SubReddit> Create(SubReddit subreddit)
        {
            var reddit = await _context.Subreddits.AddAsync(subreddit);   
            await _context.SaveChangesAsync();
            return reddit.Entity;
        }

        public async void Delete(int id)
        {
            var subredditId = await _context.Subreddits.FirstOrDefaultAsync(x => x.Id == id);
            if(subredditId != null)
            {
                _context.Subreddits.Remove(subredditId);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<SubReddit>> Get()
        {
            var subreddit = await _context.Subreddits.ToListAsync();
            return subreddit;
        }

        public async Task<SubReddit> GetById(int id)
        {
            var subredditID = await _context.Subreddits.Include(a=>a.Posts).FirstOrDefaultAsync(x => x.Id == id);
            return subredditID;
        }

        public async Task<SubReddit> Update(SubReddit subreddit, int id)
        {
            var subredditId = await _context.Subreddits.FirstOrDefaultAsync(x => x.Id == id);

            if(subredditId != null)
            {
                
                subredditId.Name = subreddit.Name;
                subredditId.Description = subreddit.Description;

                await _context.SaveChangesAsync();
            }

            return subreddit;
        }
    }
}
