using FeedReader.Repository.Model;
using System.Threading.Tasks;

namespace FeedReader.Services
{
    public interface IFeedService
    {
        Task<Feed> GetByIdWithCategory(int feedId);
    }
}
