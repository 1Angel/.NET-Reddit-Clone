﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RedditClone.Data;
using RedditClone.Dtos;
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

        public async Task<SubReddit> Create(SubReddit subreddit, string UserId)
        {
            subreddit.AppUserId = UserId;
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

        public async Task<List<SubReddit>> Get(PaginationFilterDto paginationFilterDto)
        {
            var subRedditQueryable = _context.Subreddits.AsQueryable();

            var pagedData = await subRedditQueryable.OrderBy(x=>x.Id).Skip((paginationFilterDto.PageNumber -1) * paginationFilterDto.PageSize).Take(paginationFilterDto.PageSize).ToListAsync();

            return pagedData;
        }

        public async Task<SubReddit> GetById(int id)
        {
            var subredditID = await _context.Subreddits.Include(a=>a.Posts).ThenInclude(a=>a.AppUser).FirstOrDefaultAsync(x => x.Id == id);
            return subredditID;
        }

        public async Task<List<SubReddit>> GetByTitle(SearchFilterDto searchFilterDto)
        {
            var SubRedditQueryable = _context.Subreddits.AsQueryable();

            if (!string.IsNullOrEmpty(searchFilterDto.SearchTerm))
            {
               SubRedditQueryable = SubRedditQueryable.Where(x=>x.Name.Contains(searchFilterDto.SearchTerm) || x.Description.Contains(searchFilterDto.SearchTerm));
            }

            var subReddit = await SubRedditQueryable.ToListAsync();

            return subReddit;
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
