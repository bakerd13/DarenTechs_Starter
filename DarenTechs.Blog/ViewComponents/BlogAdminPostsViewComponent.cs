using Microsoft.AspNetCore.Mvc;
using DarenTechs.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DarenTechs.Data.Data;
using DarenTechs.Blog.ViewModels;
using DarenTechs.Data.Interfaces;
using DarenTechs.Data.Entities.Blog;

namespace DarenTechs.Blog.ViewComponents
{
    public class BlogAdminPostsViewComponent : ViewComponent
    {

        private readonly IRepositoryAsync<Post> _repository;

        public BlogAdminPostsViewComponent(IRepositoryAsync<Post> repository)
        {
            _repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool isPublished, string blogAction)
        {
            var viewModel = new BlogAdminPostsViewModel(_repository);
            viewModel.IsPublished = isPublished;
            viewModel.Action = blogAction;

            var isCompleted = await viewModel.GetPostsAsync();
            return View(viewModel);
        }
    }
}
