using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using FeedReader.Repository;
using FeedReader.Repository.Model;
using Newtonsoft.Json;

namespace FeedReader.Web
{
    public class FeedReaderDbInitializer : IDatabaseInitializer<FeedReaderContext>
    {
        public void InitializeDatabase(FeedReaderContext context)
        {
            if (context.Database.Exists())
            {
                if (!context.Database.CompatibleWithModel(true))
                {
                    context.Database.Delete();
                    context.Database.Create();
                }
            }
            else
            {
                context.Database.Create();
            }

            var data = JsonConvert.DeserializeObject<JsonFile>(File.ReadAllText(HttpContext.Current.Server.MapPath("data.json")));

            var categoryId = 1;
            var feedId = 1;
            var articleId = 1;
            foreach (var jsonCategory in data.Categories)
            {
                var category = new Category() {
                    Id = categoryId++,
                    Name = jsonCategory.Name,
                    Image = "/Content/Categories/" + jsonCategory.Name.ToLower().Replace(' ', '_') +  ".jpg"
                };
                context.Categories.AddOrUpdate(p => p.Id, category);
                
                foreach(var jsonFeed in jsonCategory.Feeds)
                {
                    var feed = new Feed()
                    {
                        Id = feedId++,
                        Name = jsonFeed.Name,
                        Category = category,
                        CategoryId = category.Id,
                        Description = jsonFeed.Name + " articles",
                        Image = "/Content/Feed/" + jsonFeed.Name.ToLower().Replace(' ', '_') + ".jpg"
                    };

                    context.Feeds.AddOrUpdate(p => p.Id, feed);

                    foreach (var jsonArticle in jsonFeed.Articles)
                    {
                        var article = new Article() {
                            Id = articleId++,
                            Title = jsonArticle.Title,
                            Body = "",
                            Feed = feed,
                            FeedId = feed.Id,
                            Image = "",
                            PublishedDate = DateTime.Parse(jsonArticle.Date)
                        };
                        context.Articles.AddOrUpdate(article);
                    }
                }
            }
            context.SaveChanges();
        }
    }

    public class JsonFile
    {
        public List<JsonCategory> Categories { get; set; }
    }

    public class JsonCategory
    {
        public string Name { get; set; }
        public List<JsonFeed> Feeds { get; set; }
    }

    public class JsonFeed
    {
        public string Name { get; set; }
        public List<JsonArticle> Articles { get; set; }
    }

    public class JsonArticle
    {
        public string Title { get; set; }
        public string Date { get; set; }
    }

}