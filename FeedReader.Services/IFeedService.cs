using FeedReader.Repository.Model;
using System.Threading.Tasks;

namespace FeedReader.Services
{
    public interface IFeedService
    {
        Task<Feed> GetByIdWithCategory(int feedId);
        Task<bool> Follow(AspNetUser user);
        Task<bool> Unfollow(AspNetUser user);
        Task<bool> IsFollowed(AspNetUser user);
    }
}
