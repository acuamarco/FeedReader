using FeedReader.Repository;
using FeedReader.Services;
using FeedReader.Web.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using FeedReader.Repository.Model;

namespace FeedReader.Web.Controllers
{
    public class HomeController : Controller
    {
        private FeedReaderContext db = new FeedReaderContext();

        public async Task<ActionResult> Index()
        {
            var articleService = new ArticleService(db);
            var dashboard = new Dashboard
            {
                Categories = await db.Categories.ToListAsync(),
                Feeds = await db.Feeds.ToListAsync()
            };
            var userId = "";
            if (User.Identity.IsAuthenticated)
            {
                userId = User.Identity.GetUserId();
                dashboard.Articles = await articleService.GetByUser(userId);
            }
            dashboard.OtherArticles = await articleService.GetLast(userId);
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

        public async Task<ActionResult> Feed(int feedId, int? follow)
        {
            var feedService = new FeedService(db);
            var articleService = new ArticleService(db);
            var feed = await feedService.GetByIdWithCategory(feedId);
            var isFollowed = false;
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var user = await db.AspNetUsers.Include(u => u.Feeds).SingleOrDefaultAsync(u => u.Id == userId);
                if (follow != null)
                {
                    if (follow == 1)
                    {
                        feedService.Follow(user, feed);
                    } else
                    {
                        feedService.Unfollow(user, feed);
                    }
                }
                isFollowed = user.Feeds.Contains(feed);
            }

            var dashboard = new FeedDashboard
            {
                Feed = feed,
                Followed = isFollowed,
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