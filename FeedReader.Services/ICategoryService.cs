using FeedReader.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedReader.Services
{
    public interface ICategoryService
    {
        Task<Category> GetByIdWithFeeds(int id);
    }
}
