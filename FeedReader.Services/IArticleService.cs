using FeedReader.Repository.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeedReader.Services
{
    public interface IArticleService
    {
        Task<List<Article>> GetArticlesByCategory(int categoryId);
    }
}
