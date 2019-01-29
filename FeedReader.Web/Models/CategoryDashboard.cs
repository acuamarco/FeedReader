using FeedReader.Repository.Model;
using System.Collections.Generic;

namespace FeedReader.Web.Models
{
    public class CategoryDashboard
    {
        public Category Category { get; set; }

        public List<Article> Articles { get; set; }
    }
}