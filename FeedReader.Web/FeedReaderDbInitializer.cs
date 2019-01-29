using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using FeedReader.Repository;
using FeedReader.Repository.Model;


namespace FeedReader.Web
{
    public class FeedReaderDbInitializer : IDatabaseInitializer<FeedReaderContext>
    {
        public void InitializeDatabase(FeedReaderContext context)
        {
            if (!context.Database.Exists())
            {
                context.Database.Create();
            }

            var user1 = new AspNetUser() { Id = "marco" , Email = "marco@rodriguezcoto.com", PasswordHash = "123" };
            var user2 = new AspNetUser() { Id = "john", Email = "jdoe@none.com", PasswordHash = "123" };
            var user3 = new AspNetUser() { Id = "janne", Email = "jsmith@noemail.com", PasswordHash = "123" };
            context.AspNetUsers.AddOrUpdate(p => p.Id, user1);
            context.AspNetUsers.AddOrUpdate(p => p.Id, user2);
            context.AspNetUsers.AddOrUpdate(p => p.Id, user3);

            var category1 = new Category() { Id = 1, Name = "Sports", Image = "/Content/Categories/sports.jpg" };
            var category2 = new Category() { Id = 2, Name = "Gardening", Image = "/Content/Categories/gardening.jpg" };
            var category3 = new Category() { Id = 3, Name = "Cooking", Image = "/Content/Categories/cooking.jpg" };
            context.Categories.AddOrUpdate(p => p.Id, category1);
            context.Categories.AddOrUpdate(p => p.Id, category2);
            context.Categories.AddOrUpdate(p => p.Id, category3);


            var feed1 = new Feed() { Id = 1, Name = "Fitness", Category = category1, CategoryId = 1, Description = "Fitness articles", Image = "/Content/Categories/fitness.jpg" };
            var feed2 = new Feed() { Id = 2, Name = "Italian Food", Category = category3, CategoryId = 3, Description = "Italian Food articles", Image = "/Content/Categories/italian_food.jpg" };
            context.Feeds.AddOrUpdate(p => p.Id, feed1);
            context.Feeds.AddOrUpdate(p => p.Id, feed2);

            var article1 = new Article() { Id = 1, Title = "The 9 Best Sports to Accelerate Your Weight Loss", Body = "Swimming <br /> HIIT (High Intensity Interval Training) <br /> Running <br /> Rock Climbing <br /> Flag Football ...<br />", Feed = feed1, FeedId = 1, Image = "/Content/Categories/fitness.jpg", PublishedDate = DateTime.Parse("2018/12/24") };
            context.Articles.AddOrUpdate(article1);

            user1.Categories.Add(category1);
            user1.Categories.Add(category3);
            user2.Categories.Add(category2);
            user3.Categories.Add(category3);

            user1.Feeds.Add(feed1);
            user2.Feeds.Add(feed2);
            user3.Feeds.Add(feed1);

            feed1.Articles.Add(article1);

            context.SaveChanges();
        }
    }
}