using FeedReader.Repository.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeedReader.Services
{
    public interface IArticleService
    {
        Task<List<Article>> GetByCategory(int categoryId, int max = 12);
        Task<List<Article>> GetByFeed(int feedId, int max = 12);
        Task<Article> GetById(int articleId);
        Task<List<Article>> GetByUser(string userId, int max = 12);
        Task<List<Article>> GetLast(string userId, int max = 12);
    }
}
