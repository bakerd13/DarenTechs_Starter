using DarenTechs.Data.Entities.Blog;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarenTechs.Blog.ViewModels
{
    public class BlogViewModel
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string Slug { get; set; }

        public DateTimeOffset DatePublished { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public IHtmlContent HTMLBody
        {
            get
            {
                return new HtmlString(Body);
            }
        }

        public BlogViewModel(Post post)
        {
            Id = post.Id;
            Title = post.Title;
            Body = post.Body;
            Slug = post.Slug;
            DatePublished = post.DatePublished;
            Comments = post.Comments;
        }
    }
}
