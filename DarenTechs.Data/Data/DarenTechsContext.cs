using Microsoft.EntityFrameworkCore;
using DarenTechs.Data.Entities.Blog;
using DarenTechs.Data.Entities.Article;

namespace DarenTechs.Data.Data
{
    public class DarenTechsContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<PostTag> PostTags { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticleCategory> ArticleCategories { get; set; }

        public DarenTechsContext(DbContextOptions<DarenTechsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTag>()
            .HasKey(t => new { t.PostId, t.TagId });

            modelBuilder.Entity<PostTag>()
                .HasOne<Post>(sc => sc.Post)
                .WithMany(s => s.PostTags)
                .HasForeignKey(sc => sc.PostId);

            modelBuilder.Entity<PostTag>()
                .HasOne<Tag>(sc => sc.Tag)
                .WithMany(s => s.PostTags)
                .HasForeignKey(sc => sc.TagId);

        }
    }
}
