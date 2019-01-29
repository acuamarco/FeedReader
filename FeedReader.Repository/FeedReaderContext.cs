using System.Data.Entity;
using FeedReader.Repository.Model;

namespace FeedReader.Repository
{
    public partial class FeedReaderContext : DbContext
    {
        public FeedReaderContext()
            : base("DefaultConnection")
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Feed> Feeds { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.Body)
                .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Categories)
                .Map(m => m.ToTable("UserInterest").MapLeftKey("CategoryId").MapRightKey("UserId"));

            modelBuilder.Entity<Feed>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Feed>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Feed>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Feeds)
                .Map(m => m.ToTable("UserSubscription").MapLeftKey("FeedId").MapRightKey("UserId"));
        }
    }
}
