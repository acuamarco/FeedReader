using System.Data.Entity;
using System.Threading.Tasks;
using FeedReader.Repository;
using FeedReader.Repository.Model;

namespace FeedReader.Services
{
    public class CategoryService : ICategoryService
    {
        private FeedReaderContext context;

        public CategoryService(FeedReaderContext context)
        {
            this.context = context;
        }

        public async Task<Category> GetByIdWithFeeds(int categoryId)
        {
            return await context.Categories.Include(c => c.Feeds).SingleAsync(c => c.Id == categoryId);
        }
    }
}
