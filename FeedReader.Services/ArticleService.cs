using FeedReader.Repository;
using FeedReader.Repository.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FeedReader.Services
{
    public class ArticleService : IArticleService
    {
        private FeedReaderContext context;

        public ArticleService(FeedReaderContext context)
        {
            this.context = context;
        }

        public async Task<List<Article>> GetByCategory(int categoryId, int max = 12)
        {
            return await context.Articles
                .Where(a => a.Feed.CategoryId == categoryId)
                .OrderByDescending(a => a.PublishedDate)
                .Take(max)
                .ToListAsync();
        }

        public async Task<List<Article>> GetByFeed(int feedId, int max = 12)
        {
            return await context.Articles
                .Where(a => a.Feed.Id == feedId)
                .OrderByDescending(a => a.PublishedDate)
                .Take(max)
                .ToListAsync();
        }

        public async Task<Article> GetById(int articleId)
        {
            return await context.Articles
                .Include(a => a.Feed)
                .Where(a => a.Id == articleId)
                .SingleAsync();
        }

        public async Task<List<Article>> GetByUser(string userId, int max = 12)
        {
            return await context.Articles
                .Where(a => a.Feed.Users.Any(u => u.Id == userId))
                .OrderByDescending(a => a.PublishedDate)
                .Take(max)
                .ToListAsync();
        }

        public async Task<List<Article>> GetLast(string userId, int max = 12)
        {
            return await context.Articles
                .Where(a => a.Feed.Users.All(u => u.Id != userId))
                .OrderByDescending(a => a.PublishedDate)
                .Take(max)
                .ToListAsync();
        }
    }
}
