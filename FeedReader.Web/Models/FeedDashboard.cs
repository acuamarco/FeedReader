using FeedReader.Repository.Model;
using System.Collections.Generic;

namespace FeedReader.Web.Models
{
    public class FeedDashboard
    {
        public Feed Feed { get; set; }
        public List<Article> Articles { get; set; }
    }
}