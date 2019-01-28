using System.Linq;

namespace FeedReader.Repository.Repos
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> Query();
    }
}
