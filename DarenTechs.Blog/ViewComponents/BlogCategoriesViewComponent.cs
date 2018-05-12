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
    public class BlogCategoriesViewComponent : ViewComponent
    {
        private readonly IRepositoryAsync<Category> _repository;

        public BlogCategoriesViewComponent(IRepositoryAsync<Category> repository)
        {
            _repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new BlogCategoriesViewModel(_repository);
            var isCompleted = await viewModel.GetCategoriesAsync();
            return View(viewModel);
        }
    }
}
