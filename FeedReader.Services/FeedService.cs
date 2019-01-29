using System.Data.Entity;
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

        public void Follow(AspNetUser user, Feed feed)
        {
            if (!user.Feeds.Contains(feed))
            {
                user.Feeds.Add(feed);
                context.SaveChanges();
            }
        }

        public async Task<Feed> GetByIdWithCategory(int feedId)
        {
            return await context.Feeds.Include(f => f.Category).SingleAsync(f => f.Id == feedId);
        }

        public bool IsFollowed(AspNetUser user, Feed feed)
        {
            throw new System.NotImplementedException();
        }

        public void Unfollow(AspNetUser user, Feed feed)
        {
            if (user.Feeds.Contains(feed))
            {
                user.Feeds.Remove(feed);
                context.SaveChanges();
            }
        }
    }
}
