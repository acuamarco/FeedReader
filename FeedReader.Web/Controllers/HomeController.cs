using FeedReader.Repository;
using FeedReader.Services;
using FeedReader.Web.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FeedReader.Web.Controllers
{
    public class HomeController : Controller
    {
        private FeedReaderContext db = new FeedReaderContext();

        public async Task<ActionResult> Index()
        {
            //TODO: filter based on selection and user preferences
            var dashboard = new Dashboard();
            dashboard.Categories = await db.Categories.ToListAsync();
            dashboard.Feeds = await db.Feeds.ToListAsync();
            dashboard.Articles = await db.Articles.ToListAsync();

            return View(dashboard);
        }

        public async Task<ActionResult> Category(int categoryId)
        {
            var categoryService = new CategoryService(db);
            var articleService = new ArticleService(db);
            var dashboard = new CategoryDashboard
            {
                Category = await categoryService.GetByIdWithFeeds(categoryId),
                Articles = await articleService.GetByCategory(categoryId)
            };
            return View(dashboard);
        }

        public async Task<ActionResult> Feed(int feedId)
        {
            var feedService = new FeedService(db);
            var articleService = new ArticleService(db);
            var dashboard = new FeedDashboard
            {
                Feed = await feedService.GetByIdWithCategory(feedId),
                Articles = await articleService.GetByFeed(feedId)
            };
            return View(dashboard);
        }

        public async Task<ActionResult> Article(int articleId)
        {
            var articleService = new ArticleService(db);
            var article = await articleService.GetById(articleId);
            return View(article);
        }
    }
}