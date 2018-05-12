using DarenTechs.Data.Entities.Blog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarenTechs.Data.Data
{
    public class DarenTechsContextSeedData
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<DarenTechsContext>();

            context.Database.EnsureCreated();

            var env = serviceProvider.GetRequiredService<IHostingEnvironment>();

            if (env.IsDevelopment())
            {
                var p = await SetUpPosts(context);
            }
        }
        private static async Task<bool> SetUpPosts(DarenTechsContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category
                    {
                        Name = "General",
                        Slug = "General",
                        Description = "General Category"
                    },
                    new Category
                    {
                        Name = "Fun",
                        Slug = "Fun",
                        Description = "Fun Category"
                    }
                    );
                context.SaveChanges();
            }

            var tags = new List<Tag>();


            if (!context.Tags.Any())
            {
                tags.Add(
                    new Tag
                    {
                        Name = "WPF",
                        Slug = "/tag/wpf",
                        Description = "WPF"
                    });
                tags.Add(
                    new Tag
                    {
                        Name = "Core",
                        Slug = "/tag/Core",
                        Description = "Asp.Net Core"
                    });

                context.Tags.AddRange(tags);
                context.SaveChanges();
            }


            if (!context.Comments.Any())
            {
                var reply = new List<Comment>();
                reply.Add(new Comment
                {
                    AuthorName = "Bill",
                    Body = "This is a reply",
                    IsPublic = true
                });

                context.Comments.Add(
                        new Comment
                        {
                            AuthorName = "Jen",
                            Body = "This is a comment",
                            IsPublic = true,
                            Replies = reply
                        }
                    );
                context.SaveChanges();
            }

            if (!context.Posts.Any())
            {
                context.Posts.Add(new Post()
                {
                    Title = "Test1",
                    ShortDescription = "This is a test blog",
                    Body = "<p>A test Blog</p><br/><img src='./images/banner1.svg' alt='ASP.NET' class='img-responsive' />",
                    Slug = "Test1",
                    AuthorName = "Daren Baker",
                    IsPublic = true,
                    IsPublished = true,
                    Categories = context.Categories.Select(s => s).ToList<Category>(),
                    Comments = context.Comments.Select(s => s).ToList<Comment>()
                });

                context.SaveChanges();

                foreach (var t in tags)
                {
                    context.PostTags.Add(new PostTag
                    {
                        Post = context.Posts.FirstOrDefault(),
                        Tag = t
                    });
                }

                context.SaveChanges();
            }

            return await Task.FromResult(true);
        }
    }
}
