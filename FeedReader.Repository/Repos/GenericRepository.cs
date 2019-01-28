using System.Linq;

namespace FeedReader.Repository.Repos
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : class, new()
    {
        protected FeedReaderContext DbContext { get; set; }

        public IQueryable<T> Query()
        {
            return DbContext.Set<T>().AsQueryable();
        }
    }
}
