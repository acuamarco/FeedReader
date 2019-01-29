using FeedReader.Repository.Model;
using System.Threading.Tasks;

namespace FeedReader.Services
{
    public interface IFeedService
    {
        void Follow(AspNetUser user, Feed feed);
        Task<Feed> GetByIdWithCategory(int feedId);
        bool IsFollowed(AspNetUser user, Feed feed);
        void Unfollow(AspNetUser user, Feed feed);
        
    }
}
