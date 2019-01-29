using FeedReader.Repository.Model;
using System.Threading.Tasks;

namespace FeedReader.Services
{
    public interface IFeedService
    {
        Task<Feed> GetByIdWithCategory(int feedId);
        Task<bool> Follow(User user);
        Task<bool> Unfollow(User user);
        Task<bool> IsFollowed(User user);
    }
}
