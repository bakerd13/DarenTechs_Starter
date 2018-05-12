using DarenTechs.Blog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarenTechs.Web.Services
{
    public interface IBlogService
    {
        BlogViewModel GetLatestBlog();

        BlogPostsViewModel BlogPagedPublishedList(int page, int pageSize, bool isPublished);
    }
}
