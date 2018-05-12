using DarenTechs.Data.Entities.Blog;
using DarenTechs.Data.Interfaces;
using DarenTechs.Blog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarenTechs.Web.Services
{
    public class BlogService : IBlogService
    {
        private IRepository<Post> _repository;

        public BlogService(IRepository<Post> repository)
        {
            _repository = repository;
        }

        public BlogViewModel GetLatestBlog() => new BlogViewModel(_repository.GetAll().OrderByDescending(o => o).FirstOrDefault());

        public BlogPostsViewModel BlogPagedPublishedList(int page, int pageSize, bool isPublished)
        {
            var blogData = _repository.GetAll().Where(i => i.IsPublished == isPublished).Skip((page - 1) * pageSize).Take(pageSize);

            var blogList = new BlogPostsViewModel();
            blogList.Posts = blogData.ToList();

            return blogList;
        }
    }
}
