using DarenTechs.Data.Entities.Blog;
using DarenTechs.Data.Interfaces;
using DarenTechs.Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DarenTechs.Blog.ViewComponents
{
    public class BlogNavigationViewComponent : ViewComponent
    {
        private readonly IRepositoryAsync<Post> _repository;

        public BlogNavigationViewComponent(IRepositoryAsync<Post> repository)
        {
            _repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new BlogNavigationViewModel(_repository);
            var isCompleted = await model.PopulateTree();

            return View(model);
        }
    }
}
