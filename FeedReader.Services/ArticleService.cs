using FeedReader.Repository;
using FeedReader.Repository.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FeedReader.Services
{
    public class ArticleService
    {
        private FeedReaderContext context;

        public ArticleService(FeedReaderContext context)
        {
            this.context = context;
        }

        public async Task<List<Article>> GetArticlesByCategory(int categoryId, int max = 10)
        {
            return await context.Articles
                .Where(a => a.Feed.CategoryId == categoryId)
                .OrderByDescending(a => a.PublishedDate)
                .Take(max)
                .ToListAsync();
        }
    }
}
