using DarenTechs.Data.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace DarenTechs.Blog.ViewModels
{
    public class BlogPostsViewModel
    {
        public IList<Post> Posts { get; set; }
    }
}
