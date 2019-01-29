﻿using System.Data.Entity;
using System.Threading.Tasks;
using FeedReader.Repository;
using FeedReader.Repository.Model;

namespace FeedReader.Services
{
    public class FeedService : IFeedService
    {
        private FeedReaderContext context;

        public FeedService(FeedReaderContext context)
        {
            this.context = context;
        }

        public Task<bool> Follow(AspNetUser user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Feed> GetByIdWithCategory(int feedId)
        {
            return await context.Feeds.Include(f => f.Category).SingleAsync(f => f.Id == feedId);
        }

        public Task<bool> IsFollowed(AspNetUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Unfollow(AspNetUser user)
        {
            throw new System.NotImplementedException();
        }
    }
}
