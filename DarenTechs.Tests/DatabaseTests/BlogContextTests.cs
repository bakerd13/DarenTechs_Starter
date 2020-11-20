using DarenTechs.Data.Data;
using DarenTechs.Data.Entities.Blog;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace DarenTechsPlayArea.Tests.DatabaseTests
{
    public class BlogContextTests
    {
        private readonly Post SinglePost;

        public BlogContextTests()
        {
            SinglePost = CreateSinglePost();
        }

        [Fact]
        public void Add_A_Single_Post()
        {
            var connection = new SqlConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<DarenTechsContext>()
                    .UseSqlServer(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new DarenTechsContext(options))
                {
                    context.Database.EnsureCreated();
                }

                // Run the test against one instance of the context
                using (var context = new DarenTechsContext(options))
                {
                    var service = new Repository<Post>(context);
                    service.Add(SinglePost);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new DarenTechsContext(options))
                {
                    Assert.Equal<int>(1, context.Posts.Count());
                    Assert.Equal("Single Post", context.Posts.Single().Title);
                    Assert.Equal("Daren", context.Posts.Single().AuthorName);
                    Assert.Equal("A Short Description", context.Posts.Single().ShortDescription);
                    Assert.Equal("<b>body</b>", context.Posts.Single().Body);
                    Assert.Equal("/slug/abc-abc", context.Posts.Single().Slug);
                    Assert.Equal<DateTimeOffset>(new DateTime(2018, 05, 01), context.Posts.Single().DatePublished);
                    Assert.False(context.Posts.Single().IsDeleted);
                    Assert.False(context.Posts.Single().IsPublished);
                    Assert.True(context.Posts.Single().IsPublic);
                }
            }
            finally
            {
                connection.Close();
            }

        }

        private Post CreateSinglePost()
        {
            var post = new Post {
                Title = "Single Post",
                AuthorName = "Daren",
                ShortDescription = "A Short Description",
                Body = "<b>body</b>",
                Slug = "/slug/abc-abc",
                DatePublished = new DateTime(2018,05,01),
                IsDeleted = false,
                IsPublished = false,
                IsPublic = true
            };

            return post;
        }
    }
}
