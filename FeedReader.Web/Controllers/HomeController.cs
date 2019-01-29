using FeedReader.Repository;
using FeedReader.Services;
using FeedReader.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
            var categoryDashboard = new CategoryDashboard();
            var categoryService = new CategoryService(db);
            categoryDashboard.Category = await categoryService.GetByIdWithFeeds(categoryId);
            var articleService = new ArticleService(db);
            categoryDashboard.Articles = await articleService.GetArticlesByCategory(categoryId);
            return View(categoryDashboard);
        }
    }
}