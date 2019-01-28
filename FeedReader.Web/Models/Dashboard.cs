using FeedReader.Repository.Model;
using System.Collections.Generic;

namespace FeedReader.Web.Models
{
    public class Dashboard
    {
        public List<Category> Categories { get; set; }
        public List<Feed> Feeds { get; set; }
        public List<Article> Articles { get; set; }
    }
}