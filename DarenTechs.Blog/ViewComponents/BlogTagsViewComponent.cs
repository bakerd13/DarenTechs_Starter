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
    public class BlogTagsViewComponent : ViewComponent
    {
        private readonly IRepositoryAsync<Tag> _repository;

        public BlogTagsViewComponent(IRepositoryAsync<Tag> repository)
        {
            _repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new BlogTagsViewModel(_repository);
            var isCompleted = await viewModel.GetTagsAsync();
            return View(viewModel);
        }

    }
}
